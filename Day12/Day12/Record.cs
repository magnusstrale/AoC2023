using System.Collections.Concurrent;
using System.Data;
using System.Security.Cryptography.X509Certificates;

public class Record
{
    Dictionary<(int, int, int), long> _cache;
    string _condition;
    int[] _runs;

    public Record(string line)
    {
        var parts = line.Split(' ');
        GivenCondition = parts[0];
        GivenRuns = parts[1].Split(',').Select(int.Parse).ToArray();
        _condition = GivenCondition;
        _runs = [];
        _cache = [];
    }

    public string GivenCondition  { get; }
    public string Condition => _condition;

    public int[] GivenRuns { get; }
    public int[] Runs => _runs;

    public long ArrangementCount()
    {
        _cache.Clear();
        _condition = GivenCondition;
        _runs = GivenRuns;
        return CountArrangements(0, 0, 0);
    }

    public long ExpandedArrangementCount() 
    { 
        _cache.Clear();
        _condition = string.Join('?', GivenCondition, GivenCondition, GivenCondition, GivenCondition, GivenCondition);
        _runs = [.. GivenRuns, .. GivenRuns, .. GivenRuns, .. GivenRuns, .. GivenRuns];
        return CountArrangements(0, 0, 0);
    }

    long CountArrangements(int condIndex, int runIndex, int currentRunValue)
    {
        if (_cache.TryGetValue((condIndex, runIndex, currentRunValue), out var cachedCount))
            return cachedCount;
        if (Condition.Length == condIndex)
            return (Runs.Length == runIndex && currentRunValue == 0) || (runIndex == Runs.Length - 1 && Runs[runIndex] == currentRunValue) ? 1 : 0;
        long count = 0;
        var ch = Condition[condIndex];
        if (ch == '.' || ch == '?')
        {
            if (currentRunValue == 0)
            {
                count += CountArrangements(condIndex + 1, runIndex, 0);
            }
            else if (runIndex < Runs.Length && Runs[runIndex] == currentRunValue)
            {
                count += CountArrangements(condIndex + 1, runIndex + 1, 0);
            }
        }
        if (ch == '#' || ch == '?')
        {
            count += CountArrangements(condIndex + 1, runIndex, currentRunValue + 1);
        }
        _cache[(condIndex, runIndex, currentRunValue)] = count;
        return count;
    }
}