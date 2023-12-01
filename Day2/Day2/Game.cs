using System.Diagnostics.CodeAnalysis;

public record Game(int Id, IEnumerable<Reveal> Reveals)
{
    public static Game Parse(string line)
    {
        var idAndReveals = line.Split(':', StringSplitOptions.TrimEntries);
        var id = int.Parse(idAndReveals[0][4..]);
        var reveals = idAndReveals[1].Split(';', StringSplitOptions.TrimEntries);
        var collector = reveals.Select(r => Reveal.Parse(r)).ToArray();
        return new Game(id, collector);
    }
    public bool Possible(int maxRed, int maxGreen, int maxBlue) =>
        !Reveals.Any(r => r.Red > maxRed || r.Green > maxGreen || r.Blue > maxBlue);
    
    public int PowerOfMinimumCubes() =>
        Reveals.MaxBy(r => r.Red)!.Red *
        Reveals.MaxBy(r => r.Green)!.Green *
        Reveals.MaxBy(r => r.Blue)!.Blue;
}
