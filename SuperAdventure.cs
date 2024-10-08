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
            case 1: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n";
            case 2: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n";
            case 3:
                if (player.QuestsCompleted == 2)
                {
                    return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n";
                }
                else
                {
                    return $"You are not yet strong enough to pass onto the bridge {player.Name}\nGo back & finish 2 quests before coming back.\n\n(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n";
                }
            case 4: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n";
            case 5: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n(6) Fight the {player.CurrentLocation.MonsterLivingHere.Name}\n";
            case 6: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n";
            case 7: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n(6) Fight the {player.CurrentLocation.MonsterLivingHere.Name}\n";
            case 8: return "(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n";
            case 9: return $"(1) Move.\n(2) Look around.\n(3) Rest.\n(4) Check Inventory.\n(5) View skills.\n(6) Fight the {player.CurrentLocation.MonsterLivingHere.Name}\n";
            default: return "There was an error, please try again.";
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
                // Console.WriteLine("Do you want to use an item? (y for yes, everything else for no)");
                // string? input = Console.ReadLine()!.ToLower();
                // if(input == "y") UseItem();
                PressToContinue();
                break;
            case "5":
                Console.Clear();
                player.Inventory.SkillTree();
                PressToContinue();
                break;
            case "6":
                Console.Clear();
                if (player.CurrentLocation.MonsterLivingHere == null) {
                    Console.WriteLine("Wrong input, please input one of the shown values in the menu.\n");
                } else {
                    if (player.CurrentLocation.MonsterLivingHere.AmountKilled == 3 && player.CurrentLocation.MonsterLivingHere.ID == 1) {
                        Console.WriteLine("It seems you've already killed all the monsters in this area..\nPerhaps search elsewhere?");
                        player.CompleteQuest(1);
                        PressToContinue();
                    } else if (player.CurrentLocation.MonsterLivingHere.AmountKilled == 3 && player.CurrentLocation.MonsterLivingHere.ID == 2) {
                        Console.WriteLine("It seems you've already killed all the monsters in this area..\nPerhaps search elsewhere?");
                        player.CompleteQuest(2);
                        PressToContinue();
                    } else if (player.CurrentLocation.MonsterLivingHere.AmountKilled == 3 && player.CurrentLocation.MonsterLivingHere.ID == 3) {
                        Console.WriteLine("It seems you've already killed all the monsters in this area..\nPerhaps search elsewhere?");
                        player.CompleteQuest(3);
                        PressToContinue();
                    } else {
                        player.Attack(player.CurrentLocation.MonsterLivingHere);
                    }
                }
                break;
            default:
                Console.Clear();
                Console.WriteLine("Wrong input, please input one of the shown values in the menu.\n");
                PressToContinue();
                break;
        }
    }
    /// <summary>
    /// Functionality to use an item (for now only an health potion)
    /// </summary>
    public static void UseItem()
    {
        Console.WriteLine("Which item do you want to use? Write it's name. (write \"exit\" to leave)");
        bool chosenAction = false;

        while(!chosenAction)
        {
            string input = Console.ReadLine()!.ToLower();
            if(input == "exit") chosenAction = true;
            Item? item = player?.Inventory.FindItemByName(input);
            if(item == null) Console.WriteLine("Item not found!");
            else
            {
                if(item.Usable)
                {
                    if (item.Name == "HealthPotion")
                    {
                        player.CurrentHitPoints += player.MaximumHitPoint / 100 * 20;
                        if(player.CurrentHitPoints > player.MaximumHitPoint) player.CurrentHitPoints = player.MaximumHitPoint;
                        Console.WriteLine("You drink the health potion, feeling your wounds close up and your energy rising.");
                    }
                    chosenAction = true;
                }
                else
                {
                    Console.WriteLine("You can't use that item... I mean, not in this current state!");
                }
                
            }
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
                if (player.Inventory.Quests[World.QuestByID(1)] == false) {
                    Console.WriteLine(player.CurrentLocation.QuestAvailableHere.QuestInfo());
                    break;
                }
                break;
            case 6:
                if (player.Inventory.Quests[World.QuestByID(2)] == false) {
                    Console.WriteLine(player.CurrentLocation.QuestAvailableHere.QuestInfo());
                    break;
                }
                break;
            case 8:
                if (player.Inventory.Quests[World.QuestByID(3)] == false) {
                    Console.WriteLine(player.CurrentLocation.QuestAvailableHere.QuestInfo());
                    break;
                }
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