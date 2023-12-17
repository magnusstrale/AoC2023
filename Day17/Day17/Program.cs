var lines = File.ReadAllLines("input.txt");
var m = new RouteMap(lines);

Console.WriteLine($"Part 1 {m.CrucibleMinimumHeatLoss}");
Console.WriteLine($"Part 2 {m.UltraCrucibleMinimumHeatLoss}");
