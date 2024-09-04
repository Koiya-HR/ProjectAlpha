namespace ProjectAlpha;

class Player {

    public int MaximumHitPoint;
    public int CurrentHitPoints;
    public string Name;

    public Weapon CurrentWeapon;
    public Location CurrentLocation;

    public Player(string name, Weapon weapon, Location location, int hits) {
        
        this.Name = name;
        this.CurrentWeapon = weapon;
        this.CurrentLocation = location;
        this.CurrentHitPoints = hits;

    }

}