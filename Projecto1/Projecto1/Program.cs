using System;


namespace Projecto1
{
    // En C# este paso es necesario, previo a declarar el evento dentro de una clase
    public delegate void AttackEventHandler(int damage); // Primero declaro el tipo de dato del evento

    class Program
    {
        static void Main()
        {
            // Player
            Character pepe = new Character();

            // Crear pull de enemigos
            Enemy enemigo = new Enemy(pepe);
            Enemy enemigo2 = new Enemy(pepe);
            Enemy enemigo3 = new Enemy(pepe);
            Enemy enemigo4 = new Enemy(pepe);
            
            //FireRing Anillo = new FireRing();
            //SpikeArmour armadura = new SpikeArmour();


            //Console.WriteLine("Armour test (Action being overwritted to change the target of the damage)");
            
            //armadura.Equip(enemigo);
            pepe.Attack(50);
            Console.WriteLine("Soy el enemigo y tengo esta vida:" + enemigo.Health);
            Console.WriteLine("Soy el enemigo2 y tengo esta vida:" + enemigo2.Health);
            Console.WriteLine("Soy el enemigo3 y tengo esta vida:" + enemigo3.Health);
            Console.WriteLine("Soy el enemigo4 y tengo esta vida:" + enemigo4.Health);

          //  Console.ReadLine();
          //  Console.Clear();

          //  Console.WriteLine("Action making 2 attacks at the same time with just one call");
          //  Anillo.Equip(pepe);

          //  pepe.Attack(enemigo);

          //  Console.ReadLine();
          //  Console.Clear();

          //  Console.WriteLine("Unequip object and attacking again");
          //  Anillo.Unequip();

          //  pepe.Attack(enemigo);
          //  Console.ReadLine();


        }
    }
/*
    public class FireRing
    {
        private Character owner = null;
        public void Equip(Character newOwner)
        {
            owner = newOwner;
            Console.WriteLine("Anillo Equipado");
            newOwner.OnAttack += OwnerAttack;
        }
        public void Unequip()
        {
            if (owner.OnAttack != null)
            {
                owner.OnAttack -= OwnerAttack; 
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
            if (owner.OnAttack != null)
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
*/
    
    public class Character
    {
        public string name;
        public event AttackEventHandler OnAttack; // Preparo el tipo de dato del evento que voy a publicar

        public Character()
        {
            name = "pepe";
        }


        public void Attack(int damage)
        {
            Console.WriteLine($"El personaje ataca!!!");

            // Si este metodo se ejecuta, este evento sera publicado, y alguien devera subscribirse, 
            // de otro modo, solo se ejecutara el Console.WriteLine de arriba
            OnAttack?.Invoke(damage); 
        }

       
    }

    public class Enemy
    {
        Character player; // Preparo el tipo de dato del publicador del evento
        public int Health = 100;

        // Constructor del objeto, se llama al inicializar el objeto
        public Enemy(Character player) // Obtengo la referencia del publicador
        {
            this.player = player; // Copio la referencia en mi propiedad de clase para luego usarla en otro metodo
            this.player.OnAttack += receiveDamage; // Me subscribo a su evento, guardame el metodo de esta clase, que quiero que sea disparado cuando el player lo invoque
        }

        // Destructor del objeto, se llama cuando no se usa mas y es recolectado
        ~Enemy()
        {
            player.OnAttack -= receiveDamage; // Me desubscribo de su evento
        }

        // Yo elijo este metodo para "escuchar" el evento de ataque del player
        public void receiveDamage(int damage)
        {
            Console.WriteLine($"Has recivido daño de parte de {player.name}");  
            Health -= damage + 10;         
        }
    }
   
}
