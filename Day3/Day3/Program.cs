var lines = File.ReadAllLines("input.txt");
var map = new Map(lines);

//Part 1 556367
//Part 2 89471771
Console.WriteLine($"Part 1 {map.SumEngineParts()}");
Console.WriteLine($"Part 2 {map.SumGearRatio()}");