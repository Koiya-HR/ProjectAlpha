using System.Security.Principal;

namespace ProjectAlpha;

public class SuperAdventure {

    public SuperAdventure() {
        
    }
    public static string GameMenu( Player player) {
        switch (player.CurrentLocation.ID) {
            case 1: return "(1) Move.\n(2) Look around.\n(3) Rest.";
            case 2: return "(1) Move.\n(2) Look around.\n(3) Rest.";
            case 3: if (player.finishedQuests.Count < 2) {
                        return $"You are not yet strong enough to pass onto the bridge {player.Name}\nGo back & finish 2 quests before coming back.\n\n(1) Move.\n(2) Look around.\n(3) Rest.";
                    } else {
                        return "(1) Move.\n(2) Look around.\n(3) Rest.";
                    }
            case 4: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Talk to the alchemist.";
            case 5: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Fight the {player.CurrentLocation.MonsterLivingHere.Name}s.";
            case 6: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Talk to the farmer.";
            case 7: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Fight the {player.CurrentLocation.MonsterLivingHere.Name}s";
            case 8: return "(1) Move.\n(2) Look around.\n(3) Rest.";
            case 9: return "(1) Move.\n(2) Look around.\n(3) Rest.";
            default: return "There was an error, please try again.";
        }
    }

    public static void PlayerChoice(Player player, int choice)  {
        switch (choice) {
            case 1: player.Move(); 
                    break;
            case 2: Console.WriteLine($"You are currently at {player.CurrentLocation.Name}.");
                    Console.WriteLine(player.CurrentLocation.Description);
                    break;
            case 3: if (player.CurrentHitPoints < player.MaximumHitPoint) {
                        player.CurrentHitPoints = player.MaximumHitPoint;
                    } else {
                        Console.WriteLine("You're already at full HP.");
                    }
                    break;
        }
    }
}