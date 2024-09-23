namespace ProjectAlpha;

public static class SuperAdventure
{
    public static Player? player = null;

    public static void SetPlayer() {
        Console.Write("What is your name?: ");
        player = new(Console.ReadLine());

        // don't allow nameless players
        if (player.Name == "")
            player.Name = "Player";
    }

    public static string GameMenu()
    {   
        Console.Clear();
        switch (player.CurrentLocation.ID)
        {
            case 1: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n";
            case 2: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n";
            case 3:
                if (player.FinishedQuest() < 2)
                {
                    return $"You are not yet strong enough to pass onto the bridge {player.Name}\nGo back & finish 2 quests before coming back.\n\n(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n";
                }
                else
                {
                    return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n";
                }
            case 4: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n";
            case 5: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) Fight the {player.CurrentLocation.MonsterLivingHere.Name}\n";
            case 6: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n";
            case 7: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) Fight the {player.CurrentLocation.MonsterLivingHere.Name}\n";
            case 8: return "(1) Move.\n(2) Look around.\n(3) Rest.(4) Check Inventory.\n";
            case 9: return $"(1) Move.\n(2) Look around.\n(3) Rest.(4) Check Inventory.\n(5) Fight the {player.CurrentLocation.MonsterLivingHere.Name}\n";
            default: return "There was an error, please try again.(4) Check Inventory.";
        }
    }

    public static void PlayerChoice(Player player, string? choice)
    {
        switch (choice)
        {
            case "1":
                NextTurn();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine($"You are currently at {player.CurrentLocation.Name}\n.");
                Console.WriteLine($"{player.CurrentLocation.Description}\n");
                PressToContinue();
                break;
            case "3":
                Console.Clear();
                if (player.CurrentHitPoints < player.MaximumHitPoint)
                {
                    player.CurrentHitPoints = player.MaximumHitPoint;
                    Console.WriteLine($"You healed to full HP!");
                    Console.WriteLine($"Your current HP is: {player.CurrentHitPoints}/{player.MaximumHitPoint}\n");
                }
                else
                {
                    Console.WriteLine("You're already at full HP.\n");
                }
                PressToContinue();
                break;
            case "4":
                Console.Clear();
                player.Inventory.Represent();
                PressToContinue();
                break;
            case "5":
                player.Attack(player.CurrentLocation.MonsterLivingHere);
                break;
            default:
                break;
        }
    }

    public static bool DirectionPossible(Dictionary<string, int> IDtoLetter, List<Location> PossibleDirections, string locationToGo) {
        foreach (Location location in PossibleDirections) {
            if (IDtoLetter.ContainsKey(locationToGo)) {
                if (location.ID == IDtoLetter[locationToGo]) {
                    player.CurrentLocation = location;
                    return true;
                }    
            }
        }
        return false;
    }
    public static void NextTurn() {
        Console.Clear();
        Dictionary<string, int> IDToLetter = new Dictionary<string, int>() {
            {"H", 1},
            {"T", 2},
            {"G", 3},
            {"A", 4},
            {"P", 5},
            {"F", 6},
            {"V", 7},
            {"B", 8},
            {"S", 9}
        };

        List<Location> PossibleDirections = player.CurrentLocation.Map(player);
        string? locationToGo;
        bool continueLoop = true;
        while (continueLoop) {
            Console.WriteLine($"Where would you like to go, {player.Name}?");
            locationToGo = Console.ReadLine()?.ToUpper();
            Console.Clear();
            while (locationToGo == null) {
                Console.WriteLine($"Where would you like to go, {player.Name}?");
                locationToGo = Console.ReadLine()?.ToUpper();
                Console.Clear();
            }
            if (DirectionPossible(IDToLetter, PossibleDirections, locationToGo)) {
                Console.WriteLine($"You travelled to {player.CurrentLocation.Name}, {player.Name}\n");
                Console.WriteLine($"{player.CurrentLocation.Description}\n");
                continueLoop = false;
            } else {
                Console.WriteLine("This location is not valid. Please enter one of the Letters (excluding X) as shown on the map.");
                player.CurrentLocation.Map(player);
            }
        }

        switch (player.CurrentLocation.ID)
        {
            case 4:
                Console.WriteLine(player.CurrentLocation.QuestAvailableHere.QuestInfo());
                break;
            case 6:
                Console.WriteLine(player.CurrentLocation.QuestAvailableHere.QuestInfo());
                break;
            case 8:
                Console.WriteLine(player.CurrentLocation.QuestAvailableHere.QuestInfo());
                break;
            default:
                break;
        }

        PressToContinue();
    }

    public static void PressToContinue() {
        Console.WriteLine("\n\nPress enter to continue.");
        string? input = Console.ReadLine();
    }

    public static void MainGameLoop() {
        SetPlayer();
        while (player.Inventory.Quests.Values.Contains(false))
        {
            Console.WriteLine(GameMenu());
            string? choice = Console.ReadLine();

            while (choice == "") {
                Console.WriteLine("Please pick one of the numerical values as given below:");
                Console.WriteLine(GameMenu());
                choice = Console.ReadLine();
            }

            PlayerChoice(player, choice);
        }
    }
}