namespace ProjectAlpha;

public class Program {
    public static void Main(string[] args) {
        
        Console.Write("What is your name?: ");
        Player player = new(Console.ReadLine() ?? "Player");

        while (player.Inventory.Quests.Values.Contains(false))
        {
            Console.WriteLine(SuperAdventure.GameMenu(player));
            int choice = Convert.ToInt32(Console.ReadLine());
            SuperAdventure.PlayerChoice(player, choice);
        }
    }
}