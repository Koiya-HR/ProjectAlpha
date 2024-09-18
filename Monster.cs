namespace ProjectAlpha;
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

    public void AddReward(Player player)
    {
        if (!IsAlive)
        {
            List<string> giveReward = new List<string> { "Health Potion" };

            // Reward chance 50/50
            if (rnd.Next(0, 2) == 1)
            {
                string reward = giveReward[0];
                player.Inventory.Add(reward);
                Console.WriteLine($"You have received a {reward} for defeating the monster!");
            }
            else
            {
                Console.WriteLine("The monster did not drop any items.");
            }
        }
        else
        {
            Console.WriteLine("The monster is still alive and cannot drop any items.");
        }
    }
}