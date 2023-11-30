public class Part2
{
    string[] digitNames = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    string[] reverseDigitNames;

    public Part2()
    {
        reverseDigitNames = digitNames.Select(d => ReverseString(d)).ToArray();
    }

    public int SumLines(string[] lines) => 
        lines.Sum(GetNumber);

    int GetNumber(string line) =>
        FirstDigit(line, digitNames) * 10 + FirstDigit(ReverseString(line), reverseDigitNames);

    int FirstDigit(string line, string[] names)
    {
        for (var i = 0; i < line.Length; i++)
        {
            if (char.IsAsciiDigit(line[i])) return line[i] - '0';
            var substr = line.Substring(i);
            for (var j = 0; j < names.Length; j++)
            {
                if (substr.StartsWith(names[j])) return j + 1;
            }
        }
        throw new Exception("Boom");
    }

    string ReverseString(string str) => new string(str.Reverse().ToArray());
}