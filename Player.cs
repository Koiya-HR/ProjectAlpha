using System.Numerics;

namespace ProjectAlpha;

public class Player {

    public string Name;
    public int MaximumHitPoint;
    public int CurrentHitPoints;
    public int Damage;
    public Weapon? CurrentWeapon;
    public Location? CurrentLocation;
    public Inventory Inventory = new Inventory();
    private static Random rand = new Random();

    // adapter
    public int KilledMonsters;
    public Func<int> FinishedQuest;

    public Player(string name): this(name, World.WeaponByID(1), World.LocationByID(1), 10) { }
    public Player(string name, Weapon? currentWeapon, Location? currentLocation, int currentHitPoints) {
        
        // set base properties
        Name = name;
        CurrentWeapon = currentWeapon;
        CurrentLocation = currentLocation;
        CurrentHitPoints = currentHitPoints;
        Damage = 1;
        MaximumHitPoint = 10;

        // initialize quests
        foreach (Quest quest in World.Quests)
            Inventory.Add(quest);
            Inventory.Add(World.WeaponByID(1));

        // implement redirect (adapter)
        FinishedQuest = () => Inventory.Quests.Values.Count(completed => completed == false);
    }

    public void Attack(Monster monster)
    {
        while (monster.CurrentHitPoints > 0)
        {
            Console.WriteLine($"Monsters HP remaning: {monster.CurrentHitPoints}/{monster.MaximumHitPoints}");
            Console.WriteLine($"{Name}'s HP remaning: {CurrentHitPoints}/{MaximumHitPoint}");
            int attackDamage = Damage + CurrentWeapon.Damage;
            monster.CurrentHitPoints -= attackDamage;

            if (monster.CurrentHitPoints <= 0)
            {
                Console.WriteLine($"{monster.Name} took {attackDamage} Damage!\n");
                Console.WriteLine($"You've defeated the {monster.Name}!\n");
                SuperAdventure.PressToContinue();
                Console.Clear();
                break;
            }
            else
            {  
                Console.WriteLine($"{monster.Name} took {attackDamage} Damage!\n");
                Console.WriteLine($"{monster.Name}'s remaning HP: {monster.CurrentHitPoints}/{monster.MaximumHitPoints}");
                SuperAdventure.PressToContinue();
                Console.Clear();
            }

            int MonsterAttackDamage = rand.Next(0, monster.MaximumDamage + 1);

            if (MonsterAttackDamage == 0)
            {
                Console.WriteLine("You dodged the incoming attack!");
                SuperAdventure.PressToContinue();
                Console.Clear();
            }
            else
            {
                CurrentHitPoints -= MonsterAttackDamage;
                if (CurrentHitPoints <= 0)
                {
                    CurrentHitPoints = 0;
                    Console.WriteLine($"Your HP dropped to {CurrentHitPoints}.\nYou died.\n");
                    SuperAdventure.PressToContinue();
                    Console.Clear();
                    break;
                } else {
                    Console.WriteLine($"The {monster.Name} did {MonsterAttackDamage} damage to you!");
                    Console.WriteLine($"HP remaning: {CurrentHitPoints}/{MaximumHitPoint}");
                    SuperAdventure.PressToContinue();
                    Console.Clear();
                }
            }
        }
        monster.CurrentHitPoints = monster.MaximumHitPoints;
    }
}