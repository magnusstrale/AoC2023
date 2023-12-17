var lines = File.ReadAllLines("input.txt");
var m = new RouteMap(lines);

Console.WriteLine($"Part 1 {m.MinimumHeatLoss()}");
Console.WriteLine($"Part 2 {2}");
