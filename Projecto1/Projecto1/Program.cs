using System;


namespace Projecto1
{
    class Program
    {
        static void Main()
        {
            Character pepe = new Character();
            Character enemigo = new Character();
            FireRing Anillo = new FireRing();
            SpikeArmour armadura = new SpikeArmour();


            Console.WriteLine("Armour test (Action being overwritted to change the target of the damage)");
            armadura.Equip(enemigo);
            enemigo.reciveDamage(10, pepe);
            

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Action making 2 attacks at the same time with just one call");
            Anillo.Equip(pepe);

            pepe.attack(enemigo);

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Unequip object and attacking again");
            Anillo.Unequip();

            pepe.attack(enemigo);
            Console.ReadLine();


        }
    }

    public class FireRing
    {
        private Character owner = null;
        public void Equip(Character newOwner)
        {
            owner = newOwner;
            Console.WriteLine("Anillo Equipado");
            newOwner.attack += OwnerAttack;
        }
        public void Unequip()
        {
            if (owner.attack != null)
            {
                owner.attack -= OwnerAttack; 
                owner = null;
                Console.WriteLine("No equipado");
               
                
            }
        }
        public void OwnerAttack(Character target)
        {
            Console.WriteLine("El anillo tambien ataca");
            target.damageManager(10, owner);

        }
    }

    public class SpikeArmour
    {
        private Character owner = null;
        public void Equip(Character newOwner)
        {
            owner = newOwner;
            Console.WriteLine("Armadura Equipado");
            newOwner.reciveDamage += OwnerRecivesDamage;
            newOwner.reciveDamage -= newOwner.damageManager;
        }
        public void Unequip()
        {
            if (owner.attack != null)
            {
                owner.reciveDamage -= OwnerRecivesDamage;
                owner.reciveDamage += owner.damageManager;
                owner = null;
                Console.WriteLine("No equipado");
            }
        }
        public void OwnerRecivesDamage(int damage, Character target)
        {
            Console.WriteLine("La armadura recive el daño y ataca en su lugar");
        }
    }

    public class Character
    {
        public string name;
        public Action<Character> attack;
        public Action<int, Character> reciveDamage;

        public Character()
        {
            name = "pepe";
            attack += Attack;
            reciveDamage += damageManager;
        }

        public void Attack(Character target)
        {
            Console.WriteLine($"El personaje ataca a {target.name}");
            target.damageManager(10, this);
        }

        public void damageManager(int damage, Character damageDealer)
        {
            Console.WriteLine($"Has recivido daño de parte de {name}");
        }

       
    }
   
}
