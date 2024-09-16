namespace ProjectAlpha
{

    public class Weapon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Description {get; set;}

        public Weapon(int id, string name, int damage, string description)
        {
            ID = id;
            Name = name;
            Damage = damage;
            Description = description;
        }

        // Methode om de naam en de damage van het wapen te definieren
        public void Attack(string Name, int Damage)
        {
            Console.WriteLine($"Attacking with {Name}, dealing {Damage} damage!");
        }
    }
}