var lines = File.ReadAllLines("input.txt");
var u = new Universe(lines);

Console.WriteLine($"Part 1 {u.SumOfDistances}");
Console.WriteLine($"Part 2 {u.SumOfLargeDistances}");
