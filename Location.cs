namespace ProjectAlpha;

public class Location {
    public required int ID;
    public required string Name;
    public required string Description;
    public required Quest QuestAvailableHere;
    public required Monster MonsterLivingHere;
    public required Location LocationToNorth;
    public required Location LocationtoEast;
    public required Location LocationtoSouth;
    public required Location LocationtoWest;


    public Location(int id, string name, string description, Quest questavailablehere, Monster monsterlivinghere, Location locationtonorth, Location locationtoeast, Location locationtosouth, Location locationtowest) {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.QuestAvailableHere = questavailablehere;
        this.MonsterLivingHere = monsterlivinghere;
        this.LocationToNorth = locationtonorth;
        this.LocationtoEast = locationtoeast;
        this.LocationtoSouth = locationtosouth;
        this.LocationtoWest = locationtowest;

    }
}