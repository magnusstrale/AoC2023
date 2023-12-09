namespace Day9test;

public class UnitTest1
{
    readonly string[] lines = 
    {
        "0 3 6 9 12 15",
        "1 3 6 10 15 21",
        "10 13 16 21 30 45"
    };

    [Fact]
    public void Part1Test()
    {
        var sut = new Report(lines);
        Assert.Equal(114, sut.ExtrapolateNextSum);
    }

    [Theory]
    [InlineData("0 3 6 9 12 15", 18)]
    [InlineData("1 3 6 10 15 21", 28)]
    [InlineData("10 13 16 21 30 45", 68)]
    [InlineData("10 13 16 21 30", 45)]
    [InlineData("-1 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19", 20)]
    public void ExtrapolateNextTest(string line, int expected)
    {
        var sut = new History(line);
        Assert.Equal(expected, sut.ExtrapolateNextValue);
    }

    [Theory]
    [InlineData("0 3 6 9 12 15", -3)]
    [InlineData("1 3 6 10 15 21", 0)]
    [InlineData("10 13 16 21 30 45", 5)]
    [InlineData("10 13 16 21 30", 5)]
    [InlineData("-1 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19", -2)]
    public void ExtrapolatePreviousTest(string line, int expected)
    {
        var sut = new History(line);
        Assert.Equal(expected, sut.ExtrapolatePreviousValue);
    }


    [Fact]
    public void Part2Test()
    {
        var sut = new Report(lines);
        Assert.Equal(2, sut.ExtrapolatePreviousSum);
    }
}