namespace Day3test;

public class PaseTest
{
    string [] lines = {
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598.."};

    [Fact]
    public void Test1()
    {
        var sut = new Map(lines);
        var result = sut.SumEngineParts();
        Assert.Equal(4361, result);
    }

    [Theory]
    [InlineData("123%34", 157)]
    [InlineData("123.34", 0)]
    [InlineData("123.34+", 34)]
    [InlineData("!123.34+", 157)]
    [InlineData("!123.34", 123)]
    [InlineData("123.*34", 34)]
    public void TestRowEdgeCases(string line, int expected)
    {
        var sut = new Map(new [] {line});
        var result = sut.SumEngineParts();
        Assert.Equal(expected, result);
    }
}