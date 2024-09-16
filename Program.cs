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
            
            // redundant input-validation
            string? choice = Console.ReadLine();
            int ichoice;

            if (choice == "")
                continue;
            else
                ichoice = Convert.ToInt32(choice);
            
            SuperAdventure.PlayerChoice(player, ichoice);

        }
    }
}