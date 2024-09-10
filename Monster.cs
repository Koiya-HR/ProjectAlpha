namespace ProjectAlpha
{
    public class Monster
    {
        // field voor rng
        Random rnd = new();

        // fields voor monster properties
        public int ID;
        public string Name;
        public int MaximumDamage;
        public int CurrentHitPoints;
        public int MaximumHitPoints;

        // boolean om te checken of het monster nog leeft
        public bool IsAlive;

        // constructor
        public Monster(int id, string name, int maximumDamage, int currentHitPoints, int maximumHitPoints)
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
            IsAlive = currentHitPoints > 0;
        }

        // monster attack method
        public void MonsterAttack(Player player)
        {
            if (!IsAlive)
            {
                Console.WriteLine("The monster is dead and cannot attack.");
                return;
            }

            int damage = rnd.Next(0, MaximumDamage + 1);
            player.CurrentHitPoints -= damage;
            if (damage == 0)
            {
                Console.WriteLine("The monster attacked but missed.");
            }
            else
            {
                Console.WriteLine($"The monster attacked and did {damage} damage.");
            }

            if (player.CurrentHitPoints <= 0)
            {
                Console.WriteLine("The monster has killed you.");
            }
            else
            {
                Console.WriteLine($"Player currently has {player.CurrentHitPoints} hit points remaining.");
            }
        }

        public void MonsterHealth()
        {
            Console.WriteLine($"The monster has {CurrentHitPoints} hit points remaining.");
            if (CurrentHitPoints <= 0)
            {
                IsAlive = false;
                Console.WriteLine("The monster has been defeated.");
            }
        }

        // Method om monster te kunnen attacken, deze versie is tijdelijk want er is nog geen player class
        public void TakeDamage(int damage)
        {
            if (!IsAlive)
            {
                Console.WriteLine("The monster is already dead.");
                return;
            }

            CurrentHitPoints -= damage;

            if (CurrentHitPoints <= 0)
            {
                CurrentHitPoints = 0;
                IsAlive = false;
                Console.WriteLine("The monster has been defeated!.");
            }
            else
            {
                Console.WriteLine($"The monster took {damage} damage and now has {CurrentHitPoints} hit points remaining.");
            }
        }
    }
}
