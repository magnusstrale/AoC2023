using System.Data;

public class Solver
{
    public Solver(string[] lines)
    {
        Records = [.. lines.Select(l => new Record(l))];
    }

    public Record[] Records { get; }

    public int CountPossibleArrangements => Records.Sum(r => r.ArrangementCount());
}