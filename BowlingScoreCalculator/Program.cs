using BowlingScoreCalculator;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to bowling! How many people will be playing?");
        string playerInput = Console.ReadLine();
        int numPlayers;
        bool validPlayers = Int32.TryParse(playerInput, out numPlayers);

        while (!validPlayers) {
            Console.WriteLine("Sorry, that input was not valid. Please input an integer to indicate the number of players.");
            playerInput = Console.ReadLine();
            validPlayers = Int32.TryParse(playerInput,out numPlayers);
        }

        Game game = new Game();
        string playerName;

        for (int i = 1; i <= numPlayers; i++) {
            Console.WriteLine("Please input a name for player" + i);
            playerName = Console.ReadLine();
            game.AddPlayer(String.IsNullOrWhiteSpace(playerName) ? "Player"+i : playerName);
        }

        for (int i = 0; i < 10; i++) {
            foreach (var player in game.Players) {
                player.GetThrows(player.Round[i]);
            }
        }

        foreach(var player in game.Players) {
            player.CalculateFinalScore();
        }

        game.CalculateStandings();

        for(int i = 0; i < game.FinalStandings.Count; i++) {
            Player currentPlayer = game.FinalStandings[i];
            string placeSuffix = "";
            switch (i+1) {
                case 1:
                    placeSuffix = "st";
                    break;
                case 2:
                    placeSuffix = "nd";
                    break;
                case 3:
                    placeSuffix = "rd";
                    break;
                default:
                    placeSuffix = "th";
                    break;
            }
            Console.WriteLine(currentPlayer.Name + " is in " + (i+1) + placeSuffix + " place with a score of "+ currentPlayer.FinalScore);
        }
    }
}