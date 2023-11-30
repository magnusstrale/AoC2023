public class Part1
{
    public int SumLines(string[] lines) => 
        lines.Sum(GetNumber);

    public int GetNumber(string line) =>
        FirstDigit(line) * 10 + FirstDigit(line.Reverse());

    public int FirstDigit(IEnumerable<char> line) =>
        line.First(char.IsAsciiDigit) - '0';
}