namespace ProjectAlpha;

public class Program {
    public static void Main(string[] args) {
        SuperAdventure.SetPlayer();
        while (SuperAdventure.player.Inventory.Quests.Values.Contains(false))
        {
            Console.WriteLine(SuperAdventure.GameMenu());
            string? choice = Console.ReadLine();

            while (choice == "") {
                Console.WriteLine("Please pick one of the numerical values as given below:");
                Console.WriteLine(SuperAdventure.GameMenu());
                choice = Console.ReadLine();
            }

            SuperAdventure.PlayerChoice(SuperAdventure.player, choice);
        }
    }
}