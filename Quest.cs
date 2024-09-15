namespace ProjectAlpha;

/*
Sprint Items

- The reward is added to the inventory of the player.
- The reward can be a new weapon or a health potion.
- When the player enters a location with a quest, 
  give the user the option to speak to an NPC who will give the player a quest.
*/

public class Quest(
    int id,
    string name,
    string description,
    string npcDialogue,
    int difficulty)
{
    public Random rand = new();
    public int ID = id;
    public string Name = name;
    public string Description = description;
    public string NpcDialogue = npcDialogue;
    public int Difficulty = difficulty;

    /// <summary>
    /// Stuur de quest naam terug met de character dialogue erin
    /// </summary>
    /// <returns>Quest naam, quest info en character dialogue in string formaat</returns>
    public string QuestInfo() => $"*{Name}*\nQuest objective: {Description}\n{NpcDialogue}";

    /// <summary>
    /// Een quest completen en XP rewards bepalen -- Nog een "concept"
    /// </summary>
    /// <returns>Een list met type "object" met de eerste value de XP die je verdient, en de rest zijn de rewards</returns>
    public List<object> QuestComplete()
    {
        List<object> rewards = [];

        int chance = rand.Next(1, 101);

        rewards.Add(difficulty * 100); // Aantal XP verdiend
        
        if(Difficulty > 1)
        {
            chance += Difficulty * 5;
        }

        if(chance >= 50) rewards.Add("Health potion");
        if(chance >= 75) rewards.Add("Sword");
        if(rewards.Count != 3 && chance >= 90) rewards.Add("MOST EPICEST OF SWORDS!!1");

        return rewards;
    }
}