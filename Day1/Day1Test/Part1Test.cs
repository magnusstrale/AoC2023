namespace Day1Test;

public class Part1Test
{
    [Theory]
    [InlineData("1abc2", 1)]
    [InlineData("zoneight234", 2)]
    public void TestFirstDigit(string input, int result)
    {
        var sut = new Part1();
        Assert.Equal(result, sut.FirstDigit(input));
    }

    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("zoneight234", 24)]
    [InlineData("treb7uchet", 77)]
    public void TestGetNumber(string input, int result)
    {
        var sut = new Part1();
        Assert.Equal(result, sut.GetNumber(input));
    }

    [Fact]
    public void TestSumLines()
    {
        var sut = new Part1();
        var lines = new [] {"1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"};
        Assert.Equal(142, sut.SumLines(lines));
    }
}