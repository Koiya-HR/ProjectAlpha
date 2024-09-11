namespace ProjectAlpha
{
    public class Monster
    {
        /// <summary>
        /// field voor rng
        /// </summary>
        Random rnd = new();

        /// <summary>
        /// fields voor monster properties
        /// </summary>
        public int ID;
        public string Name;
        public int MaximumDamage;
        public int CurrentHitPoints;
        public int MaximumHitPoints;
        /// <summary>
        /// boolean om te checken of het monster nog leeft
        /// </summary>
        public bool IsAlive;
        List<string> killRewards = new List<string>();

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

        /// <summary>
        /// monster attack method
        /// </summary>
        /// <param name="player"></param>
        public void MonsterAttack(Player player)
        {
            if (!IsAlive)
            {
                Console.WriteLine("The monster is dead and cannot attack.");
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

        /// <summary>
        /// Method om monster te kunnen attacken, deze versie is tijdelijk want er is nog geen player class
        /// </summary>
        /// <param name="damage">Hoeveel dmg</param>
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
