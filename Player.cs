using System.Numerics;

namespace ProjectAlpha;

public class Player {

    public string Name;
    public int MaximumHitPoint;
    public int CurrentHitPoints;
    public Weapon? CurrentWeapon;
    public Location? CurrentLocation;
    public Inventory Inventory = new Inventory();

    // adapter
    public int KilledMonsters;
    public Func<int> FinishedQuest;

    public Player(string name): this(name, World.WeaponByID(1), World.LocationByID(1), 30) { }
    public Player(string name, Weapon? currentWeapon, Location? currentLocation, int currentHitPoints) {
        
        // set base properties
        this.Name = name;
        
        this.CurrentWeapon = currentWeapon;
        this.CurrentLocation = currentLocation;
        
        this.CurrentHitPoints = currentHitPoints;
        this.MaximumHitPoint = currentHitPoints;

        // initialize quests
        foreach (Quest quest in World.Quests)
            this.Inventory.Add(quest);
            this.Inventory.Add(World.WeaponByID(1));

        // implement redirect (adapter)
        this.FinishedQuest = () => this.Inventory.Quests.Values.Count(completed => completed == false);

    }
}