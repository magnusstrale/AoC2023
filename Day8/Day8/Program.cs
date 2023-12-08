var lines = File.ReadAllLines("input.txt");

var n = new Navigation(lines);
Console.WriteLine($"Part 1 {n.StepsToFinish}");
Console.WriteLine($"Part 2 {n.GhostStepsToFinish}");
