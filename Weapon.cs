namespace ProjectAlpha
{
    // Verschillende wapens wordt hier genummerd
    public enum WeaponType
    {
        Melee,
        Ranged,
        Explosive
    }

    public class Weapon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public WeaponType Type { get; set; }

        public Weapon(int id, string name, int damage, WeaponType type)
        {
            ID = id;
            Name = name;
            Damage = damage;
            Type = type;
        }

        // Method van het wapen
        public void DescribeWeapon()
        {
            Console.WriteLine($"Weapon: {Name}, Damage: {Damage}, Type: {Type}");
        }

        // Methode om de naam en de damage van het wapen te definieren
        public void Attack()
        {
            Console.WriteLine($"Attacking with {Name}, dealing {Damage} damage!");
        }
    }

    // Hier wordt wapen: Bazooka gedefinieerd
    public class Bazooka : Weapon
    {
        public Bazooka() : base(1, "Bazooka", 80, WeaponType.Explosive)
        {
        }
    }

    // Hier wordt weapon: Sword gedefinieerd
    public class Sword : Weapon
    {
        public Sword() : base(2, "Sword", 50, WeaponType.Melee)
        {
        }
    }

    // Hier wordt weapon: Bow gedefinieerd
    public class Bow : Weapon
    {
        public Bow() : base(3, "Bow", 40, WeaponType.Ranged)
        {
        }
    }
}