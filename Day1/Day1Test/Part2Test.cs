namespace Day1Test;

public class Part2Test
{
    [Theory]
    [InlineData("nin4eeightseven2", 4)]
    [InlineData("xt3wone3four", 3)]
    [InlineData("ontwo1nine", 2)]
    [InlineData("two1nine", 2)]
    public void TestFirstDigit(string input, int result)
    {
        var sut = new Part2();
        Assert.Equal(result, sut.FirstDigit(input));
    }

    [Theory]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("xtwone3four", 24)]
    [InlineData("two1nine", 29)]
    public void TestGetNumber(string input, int result)
    {
        var sut = new Part2();
        Assert.Equal(result, sut.GetNumber(input));
    }

    [Fact]
    public void TestSumLines()
    {
        var sut = new Part2();
        var lines = new [] {"two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" };
        Assert.Equal(281, sut.SumLines(lines));
    }
}