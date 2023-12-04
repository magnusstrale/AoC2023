var lines = File.ReadAllLines("input.txt");
var pile = new Pile(lines);

Console.WriteLine($"Part 1 {pile.SumWinningCards}");
Console.WriteLine($"Part 2 {pile.CountTotalCards}");
