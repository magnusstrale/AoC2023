var lines = File.ReadAllLines("input.txt");

var s = new InitializationManual(lines[0]);

Console.WriteLine($"Part 1 {s.HashCodeSum}");
Console.WriteLine($"Part 2 {s.InterpretInstructions()}");
