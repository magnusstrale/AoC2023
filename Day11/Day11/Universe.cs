using Pos = (long row, long col);

public class Universe
{
    public Universe(string[] lines)
    {
        var rows = lines.Length;
        var cols = lines[0].Length;
        StartingGalaxies = lines
            .SelectMany(l => l)
            .Zip(Enumerable.Range(0, rows * cols))
            .Where(c => c.First == '#')
            .Select(c => (row: (long)(c.Second / cols), col: (long)(c.Second % cols)))
            .ToArray();
    }

    public Pos[] StartingGalaxies { get; }

    public Pos[] ScaledGalaxies(long expansion)
    {
        var emptyRows = EmptyEntries(p => p.row);
        var emptyCols = EmptyEntries(p => p.col);
        return StartingGalaxies.Select(p => 
            (p.row + emptyRows.Where(r => r < p.row).Count() * expansion,
            p.col + emptyCols.Where(c => c < p.col).Count() * expansion)).ToArray();
    }

    int[] EmptyEntries(Func<Pos, long> extractEntity)
    {
        var max = (int)StartingGalaxies.Max(extractEntity);
        var filledEntries = StartingGalaxies.Select(extractEntity).Distinct().ToArray();
        return Enumerable.Range(0, max + 1).Where(e => !filledEntries.Contains(e)).ToArray();
    }

    public long SumOfDistances =>
        SumOfScaledDistances(2);

    public long SumOfLargeDistances =>
        SumOfScaledDistances(1_000_000);
        
    public long SumOfScaledDistances(long scale) =>
        GalaxyPairs(ScaledGalaxies(scale - 1)).Sum(g => ManhattanDistance(g.Item1, g.Item2));

    public (Pos, Pos)[] GalaxyPairs(Pos[] galaxies)
    {
        var pairs = new List<(Pos, Pos)>();
        for (int i = 0; i < galaxies.Length - 1; i++)
        {
            for (int j = i + 1; j < galaxies.Length; j++)
            {
                pairs.Add((galaxies[i], galaxies[j]));
            }
        }
        return [.. pairs];
    }

    public static long ManhattanDistance(Pos a, Pos b) =>
        Math.Abs(a.col - b.col) + Math.Abs(a.row - b.row);
}