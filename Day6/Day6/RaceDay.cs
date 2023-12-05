public class RaceDay
{
    public RaceDay(string[] lines)
    {
        var times = SplitNumbers(lines[0]);
        var distances = SplitNumbers(lines[1]);
        Races = times.Zip(distances, (t, d) => new RaceInfo(t, d)).ToArray();
        LongRace = new RaceInfo(LongNumber(lines[0]), LongNumber(lines[1]));
    }

    static int[] SplitNumbers(string line) =>
        line
            .Split(":")[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();

    static long LongNumber(string line) =>
        long.Parse(line
            .Split(":")[1]
            .Replace(" ", ""));
    
    public RaceInfo[] Races { get; }
    public RaceInfo LongRace {get;}

    public long Part1 =>
        Races
            .Select(r => r.WaysToWinCount)
            .Aggregate(1, (acc, next) => acc * next);

    public long Part2 => LongRace.WaysToWinCalculated();
}