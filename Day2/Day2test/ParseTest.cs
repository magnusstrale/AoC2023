namespace Day2test;
public class ParseTest
{
    [Theory]
    [InlineData("1 blue", 0, 0, 1)]
    [InlineData("3 blue, 4 red", 4, 0, 3)]
    [InlineData("3 green, 15 blue, 14 red", 14, 3, 15)]
    public void TestParseReveal(string line, int red, int green, int blue)
    {
        var result = Reveal.Parse(line);
        var expected = new Reveal(red, green, blue);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestParseGame()
    {
        var result = Game.Parse("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
        var expected = new Game(1, new [] { new Reveal(4, 0, 3), new Reveal(1, 2, 6), new Reveal(0, 2, 0)});
        Assert.Equivalent(result, expected);
    }
}