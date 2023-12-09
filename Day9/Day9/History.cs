public class History
{
    public History(string line)
    {
        Values = line.Split(' ').Select(int.Parse).ToArray();
    }

    public int[] Values { get; }

    public int ExtrapolateNextValue => Extrapolate(Values);

    public int ExtrapolatePreviousValue => Extrapolate(Values.Reverse().ToArray());

    int Extrapolate(int[] source) =>
        source.All(v => v == 0) ? 0 : source[^1] + Extrapolate(source.Zip(source.Skip(1)).Select(c => c.Second - c.First).ToArray());
}