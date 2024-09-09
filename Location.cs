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

    public Location(int id, string name, string description, Quest? questavailablehere, Monster? monsterlivinghere ) {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.QuestAvailableHere = questavailablehere;
        this.MonsterLivingHere = monsterlivinghere;
    }

    public void Map() {
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
                Console.WriteLine($"From here you can go to:\n- {validDirections[1][0].Name} (T)");
                Console.WriteLine("  |\n  |\n--T---\n  X");
                break;
            case 2:
                Console.WriteLine($"From here you can go to:\n");
                Console.WriteLine($"- {validDirections[2][0].Name} (H)");
                Console.WriteLine($"- {validDirections[2][1].Name} (G)");
                Console.WriteLine($"- {validDirections[2][2].Name} (A)");
                Console.WriteLine($"- {validDirections[2][3].Name} (F)");
                Console.WriteLine("\n  |\n  A\n-FXG--\n  H");
                break;
            case 3:
                Console.WriteLine($"From here you can go to:\n");
                Console.WriteLine($"- {validDirections[3][0].Name} (B)");
                Console.WriteLine($"- {validDirections[3][1].Name} (T)");             
                Console.WriteLine("\n  |\n  |\n--TXB-\n  |");
                break;
            case 4:
                Console.WriteLine($"From here you can go to:\n");
                Console.WriteLine($"- {validDirections[4][0].Name} (T)");
                Console.WriteLine($"- {validDirections[4][1].Name} (P)");
                Console.WriteLine("\n  P\n  X\n--T---\n  |");
                break;                
            case 5:
                Console.WriteLine($"From here you can go to:\n");
                Console.WriteLine($"- {validDirections[5][0].Name} (A)");
                Console.WriteLine("\n  X\n  A\n--+---\n  |");
                break;
            case 6:
                Console.WriteLine($"From here you can go to:\n");
                Console.WriteLine($"- {validDirections[6][0].Name} (T)");
                Console.WriteLine($"- {validDirections[6][1].Name} (V)");
                Console.WriteLine("  |\n  |\nVXT---\n  |");
                break;
            case 7:
                Console.WriteLine($"From here you can go to:\n");
                Console.WriteLine($"- {validDirections[7][0].Name} (F)");
                Console.WriteLine("\n  |\n  |\nXF+---\n  |");
                break;
            case 8:
                Console.WriteLine($"From here you can go to:\n");
                Console.WriteLine($"- {validDirections[8][0].Name} (G)");
                Console.WriteLine($"- {validDirections[8][1].Name} (S)");
                Console.WriteLine("\n  |\n  |\n--+GXS\n  |");
                break;
            case 9:
                Console.WriteLine($"From here you can go to:\n");
                Console.WriteLine($"- {validDirections[9][0].Name} (B)");
                Console.WriteLine("\n  |\n  |\n--+-BX\n  |");
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
    }
}