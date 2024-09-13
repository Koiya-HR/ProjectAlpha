namespace ProjectAlpha
{

    public class Weapon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }

        public Weapon(int id, string name, int damage)
        {
            ID = id;
            Name = name;
            Damage = damage;
        }

        // Method van het wapen
        public void DescribeWeapon(string Name, int Damage)
        {
            Console.WriteLine($"Weapon: {Name}, Damage: {Damage}");
        }

        // Methode om de naam en de damage van het wapen te definieren
        public void Attack(string Name, int Damage)
        {
            Console.WriteLine($"Attacking with {Name}, dealing {Damage} damage!");
        }
    }
}