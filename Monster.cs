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
    
        // constructor
        public Monster(int id, string name, int maximumDamage, int currentHitPoints, int maximumHitPoints)
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }
        
        // monster attack method
        public void MonsterAttack(Player player)
        {
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
    }
}
