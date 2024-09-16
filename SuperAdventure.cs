namespace ProjectAlpha;

public class SuperAdventure
{
    public static string GameMenu(Player player)
    {
        switch (player.CurrentLocation.ID)
        {
            case 1: return "(1) Move.\n(2) Look around.\n(3) Rest.\n";
            case 2: return "(1) Move.\n(2) Look around.\n(3) Rest.\n";
            case 3:
                if (player.FinishedQuest() < 2)
                {
                    return $"You are not yet strong enough to pass onto the bridge {player.Name}\nGo back & finish 2 quests before coming back.\n\n(1) Move.\n(2) Look around.\n(3) Rest.\n";
                }
                else
                {
                    return "(1) Move.\n(2) Look around.\n(3) Rest.\n";
                }
            case 4: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Talk to the alchemist.\n";
            case 5: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Fight the {player.CurrentLocation.MonsterLivingHere.Name}s.\n";
            case 6: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Talk to the farmer.\n";
            case 7: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Fight the {player.CurrentLocation.MonsterLivingHere.Name}s\n";
            case 8: return "(1) Move.\n(2) Look around.\n(3) Rest.\n";
            case 9: return "(1) Move.\n(2) Look around.\n(3) Rest.\n";
            default: return "There was an error, please try again.\n";
        }
    }

    public static void PlayerChoice(Player player, string? choice)
    {
        switch (choice)
        {
            case "1":
                player.Move();
                break;
            case "2":
                Console.WriteLine($"You are currently at {player.CurrentLocation.Name}.");
                Console.WriteLine(player.CurrentLocation.Description);
                break;
            case "3":
                if (player.CurrentHitPoints < player.MaximumHitPoint)
                {
                    player.CurrentHitPoints = player.MaximumHitPoint;
                }
                else
                {
                    Console.WriteLine("You're already at full HP.");
                }
                break;
            case "4":
                Console.WriteLine("Feature(s) yet to be implemented.\n");
                break;
            default:
                break;
        }
    }
}