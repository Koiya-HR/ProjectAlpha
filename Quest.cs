using System.IO.Pipes;

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
    int npcDialogueID,
    Monster monster,
    int killsRequired,
    int questDifficulty)
{
    public int ID = id;
    public string Name = name;
    public string Description = description;
    public int NpcDialogueID = npcDialogueID;
    public Monster? Monster = monster;
    public int KillsRequired = killsRequired;
    public int QuestDifficulty = questDifficulty;

    /// <summary>
    /// Stuur de quest naam terug met de character dialogue erin
    /// </summary>
    /// <returns>Quest naam, quest info en character dialogue in string formaat</returns>
    public string QuestInfo()
    {
        string text = $"*{Name}*\nQuest objective: {Description}\n";
        switch (NpcDialogueID)
        {
            case 1:
                text +=
                @"Ah, you there! Just the sort of help I need.
                My crops—what little I’ve got—are bein' devoured by a pack of oversized rats.
                Three of the vermin, big as dogs, keep sneakin’ in at night and gnawin’ through my harvest.
                If you can rid me of the filthy creatures, I’d be mighty grateful.
                Be careful, though—they’re more cunning than they look!";
                break;
            case 2:
                text +=
                @"Ah, traveler, you've come at the right time!
                A vile nuisance has slithered its way into my work.
                Three snakes, venomous and persistent, have been devouring the very herbs I need for my most delicate concoctions.
                Without those plants, my alchemy suffers!
                If you can dispatch these wretched serpents, I will reward you handsomely...
                but be warned, they’re more dangerous than they seem.";
                break;
            case 3:
                text +=
                @"So, you've finally crawled your way to me, little insect.
                Impressive... but foolish. You think you can face me, the Spider King, so easily?
                Hah! Prove your worth first. Three of my finest brood await, lurking in the shadows.
                Defeat them, if you dare, and perhaps I’ll grant you the honor of a true fight.
                But know this—failure means you’ll join my web, forever.";
                break;
        }
        return text;
    }
    /// <summary>
    /// Een quest completen en XP rewards bepalen
    /// </summary>
    /// <param name="multiplier">De multiplier die wordt gemaakt door de Random class tussen de 1 en 3</param>
    /// <returns>Aantal XP gekregen</returns>
    public int QuestComplete(int multiplier)
    {
        int xpGained = multiplier * 100; // TO:DO als leveling systeem klaar is, 100 weghalen en met een betere systeem opkomen
        return xpGained;
    }
}