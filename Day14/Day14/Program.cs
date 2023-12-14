var lines = File.ReadAllLines("input.txt");

var p = new Platform(lines);
p.TiltNorth();
var l = p.LoadOnNorthBeams(p.Map);

Console.WriteLine($"Part 1 {l}");

p = new Platform(lines);
l = p.LoadAfterManyCycles();

Console.WriteLine($"Part 2 {l}");
