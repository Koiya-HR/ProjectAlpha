namespace ProjectAlpha;
public class Skill
{

    public int ID;
    public string Name;
    public string Description;
    public int RequiredXP;
    public int Amount;

    public Skill(int id, string name, string description, int requiredXP, int amount)
    {
        ID = id;
        Name = name;
        Description = description;
        RequiredXP  = requiredXP;
        Amount = amount;
    }

    public static void Apply(Skill skill)
    {
        if (skill.Description.ToLower().Contains("health"))
            SuperAdventure.player.MaximumHitPoint += skill.Amount;
        else
            ; // increase damage
    }

    public override string ToString() => $"|{new string('-', RequiredXP)} ({RequiredXP}) [{Name}]: {Description}";

}
