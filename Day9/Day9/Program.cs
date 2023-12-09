var lines = File.ReadAllLines("input.txt");
var report = new Report(lines);

Console.WriteLine($"Part 1 {report.ExtrapolateNextSum}");
Console.WriteLine($"Part 2 {report.ExtrapolatePreviousSum}");