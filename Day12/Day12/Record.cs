using System.Security.Cryptography.X509Certificates;

public class Record
{
    public Record(string line)
    {
        var parts = line.Split(' ');
        GivenCondition = parts[0];
        Runs = parts[1].Split(',').Select(int.Parse).ToArray();
    }

    public string GivenCondition { get; }

    public int[] Runs { get; }

    public int ArrangementCount()
    {
        var qPos = GivenCondition.Zip(Enumerable.Range(0, GivenCondition.Length)).Where(t => t.First == '?').Select(t => t.Second).ToArray();
        var condArray = GivenCondition.ToArray();
        var qCount = qPos.Length;
        long combinations = 1 << qCount;
        var validCombinations = 0;
        for (long i = 0; i < combinations; i ++)
        {
            for (var j = 0; j < qCount; j++)
            {
                long bit = 1 << j;
                condArray[qPos[j]] = (i & bit) == 0 ? '#' : '.';
            }
            if (IsValid(new string(condArray))) validCombinations ++;
        }

        return validCombinations;
    }

    public bool IsValid(string cond)
    {
        var damagedRuns = cond.Split('.', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (damagedRuns.Length != Runs.Length) return false;
        for (var i = 0; i < Runs.Length; i++)
        {
            if (damagedRuns[i].Length != Runs[i]) return false;
        }
        return true;
    }
}