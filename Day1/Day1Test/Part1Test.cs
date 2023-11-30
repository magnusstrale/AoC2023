namespace Day1Test;

public class Part1Test
{
    [Fact]
    public void TestFirstDigit()
    {
        var sut = new Part1();
        Assert.Equal(1, sut.FirstDigit("1abc2"));
        Assert.Equal(2, sut.FirstDigit("zoneight234"));
    }

    [Fact]
    public void TestGetNumber()
    {
        var sut = new Part1();
        Assert.Equal(12, sut.GetNumber("1abc2"));
        Assert.Equal(24, sut.GetNumber("zoneight234"));
        Assert.Equal(77, sut.GetNumber("treb7uchet"));
    }

    [Fact]
    public void TestSumLines()
    {
        var sut = new Part1();
        var lines = new [] {"1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"};
        Assert.Equal(142, sut.SumLines(lines));
    }
}