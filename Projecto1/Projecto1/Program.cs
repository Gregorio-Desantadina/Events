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


            pepe.attack();

            Anillo.Equip(pepe);

            pepe.attack();

            Anillo.Unequip();

            pepe.attack();
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
                owner = null;
                Console.WriteLine("No equipado");
                //Error que no puedo solucionar
                //owner.attack -= OwnerAttack; 
            }
        }
        public void OwnerAttack()
        {
            Console.WriteLine("El anillo tambien ataca");
            
        }
    }

    public class Character
    {
        public string name;
        public Action attack;

        public Character()
        {
            name = "pepe";
            attack += Attack;
        }

        public void Attack()
        {
            Console.WriteLine("El personaje ataca");  
        }

       
    }
   
}
