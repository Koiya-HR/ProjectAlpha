using System.Net;
using System.Security.Cryptography;

namespace ProjectAlpha;

/*
Sprint items:
 Show the option in which direction the player can move
 The player can input in which direction they wants to go and press enter
 The screen updates showing the new location the player is in now
 If the player inputs a direction he cannot go to an error message is displayed
*/

public class Location {
    public int ID;
    public string Name;
    public string Description;
    public Quest? QuestAvailableHere;
    public Monster? MonsterLivingHere;
    public Location? LocationToNorth;
    public Location? LocationToEast;
    public Location? LocationToSouth;
    public Location? LocationToWest;

    public Location(int id, string name, string description, Quest? questavailablehere, Monster? monsterlivinghere) {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.QuestAvailableHere = questavailablehere;
        this.MonsterLivingHere = monsterlivinghere;
    }


    public void PrintPossibleLocations(Dictionary<int, List<Location>> validDirections, int key) {
        Console.WriteLine($"From here you can go to:\n");
        for (int i = 0; i < validDirections[key].Count; i++) {
            Console.WriteLine(validDirections[key][i].Name);
        }
    }

    public List<Location>? Map() {
        Dictionary<int, List<Location>> validDirections = new Dictionary<int, List<Location>>() {
            { 1, [this.LocationToNorth] },
            { 2, [this.LocationToSouth, this.LocationToEast, this.LocationToNorth, this.LocationToWest] },
            { 3, [this.LocationToEast, this.LocationToWest] },
            { 4, [this.LocationToSouth, this.LocationToNorth] },
            { 5, [this.LocationToSouth] },
            { 6, [this.LocationToEast, this.LocationToWest] },
            { 7, [this.LocationToEast] },
            { 8, [this.LocationToWest, this.LocationToEast] },
            { 9, [this.LocationToWest] }
        };

        Console.WriteLine($"You are currently at: {this.Name} (X)");
        switch (this.ID) {
            case 1:
                PrintPossibleLocations(validDirections, 1);
                Console.WriteLine("\n  |\n  |\n--T---\n  X");
                return validDirections[1];
            case 2:
                PrintPossibleLocations(validDirections, 2);
                Console.WriteLine("\n  |\n  A\n-FXG--\n  H");
                return validDirections[2];
            case 3:
                PrintPossibleLocations(validDirections, 3); 
                Console.WriteLine("\n  |\n  |\n--TXB-\n  |");
                return validDirections[3];
            case 4:
                PrintPossibleLocations(validDirections, 4);
                Console.WriteLine("\n  P\n  X\n--T---\n  |");
                return validDirections[4];
            case 5:
                PrintPossibleLocations(validDirections, 5);
                Console.WriteLine("\n  X\n  A\n--+---\n  |");
                return validDirections[5];
            case 6:
                PrintPossibleLocations(validDirections, 6);
                Console.WriteLine("  |\n  |\nVXT---\n  |");
                return validDirections[6];
            case 7:
                PrintPossibleLocations(validDirections, 7);
                Console.WriteLine("\n  |\n  |\nXF+---\n  |");
                return validDirections[7];
            case 8:
                PrintPossibleLocations(validDirections, 8);
                Console.WriteLine("\n  |\n  |\n--+GXS\n  |");
                return validDirections[8];
            case 9:
                PrintPossibleLocations(validDirections, 9);
                Console.WriteLine("\n  |\n  |\n--+-BX\n  |");
                return validDirections[8];
            default:
                Console.WriteLine("Error");
                return null;
        }
    }
}