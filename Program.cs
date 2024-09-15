namespace ProjectAlpha;

public class Program {
    public static void Main(string[] args) {
        Console.WriteLine("What is your name, player?");
        string? playerName = Console.ReadLine();
        playerName ??= "Player";
        Player newPlayer = new(playerName, World.WeaponByID(1), World.LocationByID(1), 10);

        while (newPlayer.finishedQuests.Count < 3) {
            Console.WriteLine(SuperAdventure.GameMenu(newPlayer));
            int choice = Convert.ToInt32(Console.ReadLine());
            SuperAdventure.PlayerChoice(newPlayer, choice);
        }
    }
}