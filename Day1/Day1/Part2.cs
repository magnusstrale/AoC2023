public class Part2
{
    List<string> digitNames = new() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    public int SumLines(string[] lines) => 
        lines.Sum(GetNumber);

    public int GetNumber(string line) =>
        FirstDigit(line) * 10 + LastDigit(line);

    public int FirstDigit(string line)
    {
        int value;
        while ((value = TryDigit(line)) == 0)
            line = line[1..];
        return value;
    }

    public int LastDigit(string line)
    {
        int value;
        var index = 1;
        while ((value = TryDigit(line[^index++..])) == 0);    
        return value;
    }

    public int TryDigit(string substring) =>
        char.IsAsciiDigit(substring[0]) ? substring[0] - '0' : TryNamedDigit(substring);

    public int TryNamedDigit(string substring) =>
        digitNames.FindIndex(n => substring.StartsWith(n)) + 1; // Return value will be zero if no match
}