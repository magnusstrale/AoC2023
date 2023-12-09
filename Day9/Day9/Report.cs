public class Report
{
    public Report(string[] lines)
    {
        History = lines.Select(l => new History(l)).ToArray();
    }

    public History[] History { get; }

    public int ExtrapolateNextSum => History.Sum(h => h.ExtrapolateNextValue);

    public int ExtrapolatePreviousSum => History.Sum(h => h.ExtrapolatePreviousValue);
}