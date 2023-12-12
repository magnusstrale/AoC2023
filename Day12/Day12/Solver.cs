using System.Data;

public class Solver
{
    public Solver(string[] lines)
    {
        Records = [.. lines.Select(l => new Record(l))];
    }

    public Record[] Records { get; }

    public long CountPossibleArrangements => Records.Sum(r => r.ArrangementCount());

    public long CountExpandedArrangements => Records.Sum(r => r.ExpandedArrangementCount());
}