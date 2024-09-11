namespace ProjectAlpha;
public class Skill
{

    public string? Name;
    public string? Description;

    public int RequiredXP;

    public Skill(string name, string description, int requiredXP)
    {

        Name = name;
        Description = description;
        RequiredXP  = requiredXP;

    }

    public override string ToString() => $"|{new string('-', RequiredXP)} ({RequiredXP}) [{Name}]: {Description}";

}
