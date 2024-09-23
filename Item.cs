namespace ProjectAlpha;
public class Item
{

    public string? Name;
    public string? Description;
    public bool Usable;

    public Item(string? name, string? description, bool usable = false)
    {
        Name = name;
        Description = description;
        Usable = usable;
    }

    public override string ToString() => $"{Name} - {Description}";

}
