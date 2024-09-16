namespace ProjectAlpha;

public class Program {
    public static void Main(string[] args) {
        
        Console.Write("What is your name?: ");
        Player player = new(Console.ReadLine());

        // don't allow nameless players
        if (player.Name == "")
            player.Name = "Player";


        while (player.Inventory.Quests.Values.Contains(false))
        {
            Console.WriteLine(SuperAdventure.GameMenu(player));
            string? choice = Console.ReadLine();

            while (choice == "") {
                Console.WriteLine("Please pick one of the numerical values as given below:");
                Console.WriteLine(SuperAdventure.GameMenu(player));
                choice = Console.ReadLine();
            }

            SuperAdventure.PlayerChoice(player, choice);
        }
    }
}