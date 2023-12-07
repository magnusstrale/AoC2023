var lines = File.ReadAllLines("input.txt");

var game = new Game(lines);
Console.WriteLine($"Part 1 {game.TotalWinnings}");
Console.WriteLine($"Part 2 {game.JokerTotalWinnings}");