namespace ProjectAlpha
{
    public class Monster
    {
        /// <summary>
        /// Field for RNG
        /// </summary>
        Random rnd = new();

        /// <summary>
        /// Fields for monster properties
        /// </summary>
        public int ID;
        public string Name;
        public int MaximumDamage;
        public int CurrentHitPoints;
        public int MaximumHitPoints;

        /// <summary>
        /// Boolean to check if the monster is still alive
        /// </summary>
        public bool IsAlive;

        List<string> killRewards = new List<string>();

        /// <summary>
        /// Constructor for the Monster class
        /// </summary>
        /// <param name="id">Monster ID</param>
        /// <param name="name">Monster name</param>
        /// <param name="maximumDamage">Maximum damage the monster can deal</param>
        /// <param name="currentHitPoints">Monster's current hit points</param>
        /// <param name="maximumHitPoints">Monster's maximum hit points</param>
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
        /// Method for the monster to attack the player
        /// </summary>
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

        /// <summary>
        /// Method for dealing damage to the monster
        /// </summary>
        /// <param name="damage">Amount of damage taken by the monster</param>
        /// <param name="player">The player who dealt the damage</param>
        public void TakeDamage(int damage, Player player)
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
                Console.WriteLine($"The monster has been defeated!");
            }
            else
            {
                Console.WriteLine($"The monster took {damage} damage and now has {CurrentHitPoints} hit points remaining.");
            }
        }

        /// <summary>
        /// Method to display the monster's remaining health
        /// </summary>
        public void MonsterHealth()
        {
            Console.WriteLine($"The monster has {CurrentHitPoints} hit points remaining.");
            if (CurrentHitPoints <= 0)
            {
                IsAlive = false;
                Console.WriteLine("The monster has been defeated.");
            }
        }
    }
}