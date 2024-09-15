namespace ProjectAlpha;

public class Player {

    public int MaximumHitPoint;
    public int CurrentHitPoints;
    public string Name;

    public Weapon? CurrentWeapon;
    public Location CurrentLocation;
    public Quest? CurrentQuest;

    public List<Quest> finishedQuests;

    public Player(string name, Weapon weapon, Location location, int hits) {
        
        this.Name = name;
        this.CurrentWeapon = weapon;
        this.CurrentLocation = location;
        this.CurrentHitPoints = hits;
        this.finishedQuests = new List<Quest>();
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
    public Player(string name, Weapon currentWeapon, Location currentLocation, int currentHitPoints)
        : this(name, currentWeapon, currentLocation, currentHitPoints, new Inventory()) { }

 

}