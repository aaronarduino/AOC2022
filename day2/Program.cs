using AOCHelper;

var reader = new FileReader("", "input.txt", "test.txt");
List<string>? input = reader.ReadLines();

Dictionary<string, string> Lose = new Dictionary<string, string>()
{
    ["A"] = "C",
    ["C"] = "B",
    ["B"] = "A",
};

Dictionary<string, string> Win = new Dictionary<string, string>()
{
    ["C"] = "A",
    ["B"] = "C",
    ["A"] = "B",
};

Dictionary<string, string> Strats = new Dictionary<string, string>()
{
    ["X"] = "Loss",
    ["Y"] = "Draw",
    ["Z"] = "Win",
};

Dictionary<string, int> ShapeValues = new Dictionary<string, int>()
{
    ["A"] = 1, // Rock
    ["B"] = 2, // Paper
    ["C"] = 3, // Scissors
};

if (input != null)
{
    Console.WriteLine($"Rounds found: {input.Count}");
    int roundScore = 0;
    int gameScore = 0;

    foreach (var round in input)
    {
        // 1. Parse shapes for round
        string[] shapes = round.Split(" ");
        if (shapes.Length != 2)
        {
            Console.WriteLine($"Error: unable to parse round ({round})");
            System.Environment.Exit(1);
        }

        // 2. Get shapes for each side
        string opponentShape = shapes[0];
        string myStrat = shapes[1];

        // 3. Calc round score
        if (myStrat == "X") // Lose
        {
            var myShape = Lose[opponentShape];
            roundScore = ShapeValues[myShape];
        }
        else if (myStrat == "Y") // Draw
        {
            var myShape = opponentShape;
            roundScore = ShapeValues[myShape] + 3;
        }
        else if (myStrat == "Z") // Win
        {
            var myShape = Win[opponentShape];
            roundScore = ShapeValues[myShape] + 6;
        }

        // 4. Add round score to game score
        gameScore += roundScore;

        // Reset round score
        roundScore = 0;
    }

    Console.WriteLine(gameScore);
}
