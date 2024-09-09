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

    public static string Map(Location CurrentLocation) {
        Dictionary<int, List<int>> validDirections = new Dictionary<int, List<int>>() {
            { 1, [2] },
            { 2, [1, 3, 4, 6] },
            { 3, [2, 8] },
            { 4, [2, 5] },
            { 5, [4] },
            { 6, [2, 7] },
            { 7, [6] },
            { 8, [3, 9] },
            { 9, [8] }
        };

        switch (CurrentLocation.ID) {
            case 1:
                Console.WriteLine(validDirections[1]);
        }
    }
}