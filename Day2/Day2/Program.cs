var lines = File.ReadAllLines("input.txt");
var calc = new Calculator(lines);

Console.WriteLine($"Part 1 {calc.SumOfPossibleGames}");
Console.WriteLine($"Part 2 {calc.SumOfPowerOfMinimumCubes}");