namespace ProjectAlpha;

// TODO: docs
public class Player {

    public int MaximumHitPoint;
    public int CurrentHitPoints;
    public string Name;

    public Weapon? CurrentWeapon;
    public Location CurrentLocation;
    public Quest? CurrentQuest;

    public Inventory? Inventory;

    public Player(string name, Weapon currentWeapon, Location currentLocation, int currentHitPoints, Inventory inventory) {
        
        this.Name = name;
        this.Inventory = inventory;
        this.CurrentWeapon = currentWeapon;
        this.CurrentLocation = currentLocation;
        this.CurrentHitPoints = currentHitPoints;

    }
    public Player(string name, Weapon currentWeapon, Location currentLocation, int currentHitPoints)
        : this(name, currentWeapon, currentLocation, currentHitPoints, new Inventory()) { }

}