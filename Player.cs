using System.Numerics;

namespace ProjectAlpha;

public class Player {

    public string Name;
    public int MaximumHitPoint;
    public int CurrentHitPoints;

    public Weapon? CurrentWeapon;
    public Location CurrentLocation;
    public Inventory Inventory = new Inventory();

    // adapter
    public Func<int> FinishedQuest;

    public Player(string name): this(name, World.WeaponByID(1), World.LocationByID(1), 10) { }
    public Player(string name, Weapon? currentWeapon, Location? currentLocation, int currentHitPoints) {
        
        // set base properties
        this.Name = name;
        this.CurrentWeapon = currentWeapon;
        this.CurrentLocation = currentLocation;
        this.CurrentHitPoints = currentHitPoints;

        // initialize quests
        foreach (Quest quest in World.Quests)
            this.Inventory.Add(quest);

        // implement redirect (adapter)
        this.FinishedQuest = () => this.Inventory.Quests.Values.Count(completed => completed == false);

    }

    public bool DirectionPossible(Dictionary<string, int> IDtoLetter, List<Location> PossibleDirections, string locationToGo) {
    foreach (Location location in PossibleDirections) {
        if (location.ID == IDtoLetter[locationToGo]) {
            this.CurrentLocation = location;
            return true;
        }
    }
        return false;
    }

    public void Move() {
        Dictionary<string, int> IDToLetter = new Dictionary<string, int>() {
            {"H", 1},
            {"T", 2},
            {"G", 3},
            {"A", 4},
            {"P", 5},
            {"F", 6},
            {"V", 7},
            {"B", 8},
            {"S", 9}
        };

        List<Location> PossibleDirections = CurrentLocation.Map(this);
        string locationToGo;
        bool continueLoop = true;

        while (continueLoop) {
            Console.WriteLine($"Where would you like to go {this.Name}?");
            locationToGo =  Console.ReadLine().ToUpper();
            if (DirectionPossible(IDToLetter, PossibleDirections, locationToGo)) {
                Console.WriteLine($"You travelled to {CurrentLocation.Name}, {this.Name}");
                continueLoop = false;
            } else {
                Console.WriteLine($"You can't go to this location, {this.Name}\n");
            }
        }
    }

}