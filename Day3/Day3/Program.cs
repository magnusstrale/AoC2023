
var lines = File.ReadAllLines("input.txt");
var map = new Map(lines);

System.Console.WriteLine($"Part 1 {map.SumEngineParts()}");