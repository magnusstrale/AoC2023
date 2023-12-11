using System.Data.SqlTypes;

namespace Day11test;

public class UnitTest1
{
    string[] lines = 
    {
        "...#......",
        ".......#..",
        "#.........",
        "..........",
        "......#...",
        ".#........",
        ".........#",
        "..........",
        ".......#..",
        "#...#....."
    };

    [Fact]
    public void TestParseGalaxies()
    {
        var sut = new Universe(lines);
        Assert.Equal(9, sut.StartingGalaxies.Length);
    }

    [Theory]
    [InlineData(0, 0, 4)]
    [InlineData(1, 1, 9)]
    [InlineData(2, 2, 0)]
    [InlineData(3, 5, 8)]
    [InlineData(4, 6, 1)]
    [InlineData(5, 7, 12)]
    [InlineData(6, 10, 9)]
    [InlineData(7, 11, 0)]
    [InlineData(8, 11, 5)]
    public void TestGalaxyExpansion(int galaxyNo, int expectedRow, int expectedCol)
    {
        var sut = new Universe(lines);
        var sg = sut.ScaledGalaxies(1);
        Assert.Equal((expectedRow, expectedCol), sg[galaxyNo]);
    }

    [Fact]
    public void TestGalaxyPairs()
    {
        var sut = new Universe(lines);
        var result = sut.GalaxyPairs(sut.StartingGalaxies);
        Assert.Equal(36, result.Length);
    }

    [Theory]
    [InlineData(4, 8, 9)]
    [InlineData(0, 6, 15)]
    [InlineData(2, 5, 17)]
    [InlineData(7, 8, 5)]
    public void TestLineLength(int g1, int g2, int length)
    {
        var sut = new Universe(lines);
        var sg = sut.ScaledGalaxies(1);
        Assert.Equal(length, Universe.ManhattanDistance(sg[g1], sg[g2]));
    }

    [Fact]
    public void TestPart1()
    {
        var sut = new Universe(lines);
        Assert.Equal(374, sut.SumOfDistances);
    }

    [Fact]
    public void TestPart2_10()
    {
        var sut = new Universe(lines);
        Assert.Equal(1030, sut.SumOfScaledDistances(10));
    }

    [Fact]
    public void TestPart2_100()
    {
        var sut = new Universe(lines);
        Assert.Equal(8410, sut.SumOfScaledDistances(100));
    }
}