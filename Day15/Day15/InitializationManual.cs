public class InitializationManual(string line)
{
    Box[] Boxes { get; } = Enumerable.Range(0, 256).Select(b => new Box(b)).ToArray();

    string SourceCode { get; } = line;

    IEnumerable<string> Instructions => SourceCode.Split(',');

    public long HashCodeSum => Instructions.Sum(HashCode);

    public long InterpretInstructions()
    {
        foreach (var instruction in Instructions)
        {
            var labelFocal = instruction.Split('=', '-');
            var label = labelFocal[0];
            var box = Boxes[HashCode(label)];
            if (labelFocal[1] == "")
            {
                box.RemoveLens(label);
            }
            else
            {
                box.InsertOrReplace(new Lens(label, int.Parse(labelFocal[1])));
            }
        }

        return Boxes.Sum(b => b.FocalPower);
    }

    static long HashCode(IEnumerable<char> chars) => chars.Aggregate(0L, (acc, next) => ((acc + next) * 17) & 0xff);
}