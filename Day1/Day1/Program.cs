var lines = File.ReadAllLines("input.txt");

Console.WriteLine($"Part 1 {new Part1().SumLines(lines)}");
Console.WriteLine($"Part 2 {new Part2().SumLines(lines)}");
