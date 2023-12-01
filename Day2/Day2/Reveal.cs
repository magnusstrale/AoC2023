public record Reveal(int Red, int Green, int Blue)
{
    public static Reveal Parse(string line)
    {
        var colors = line.Split(',', StringSplitOptions.TrimEntries);
        var red = 0;
        var green = 0;
        var blue = 0;
        foreach (var color in colors)
        {
            var countAndColor = color.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var count = int.Parse(countAndColor[0]);
            switch (countAndColor[1])
            {
                case "red": red = count; break;
                case "green": green = count; break;
                case "blue": blue = count; break;
                default: throw new Exception("Boom");
            }
        }
        return new Reveal(red, green, blue);
    }

}