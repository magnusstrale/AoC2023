namespace Day6test;

public class UnitTest1
{
    public string[] lines = {
        "Time:      7  15   30",
        "Distance:  9  40  200"
    };

    [Fact]
    public void ParseTest()
    {
        var sut = new RaceDay(lines);
        Assert.Equivalent(new RaceInfo[] 
            {
                new RaceInfo(7, 9),
                new RaceInfo(15, 40),
                new RaceInfo(30, 200)
            },
            sut.Races);
    }

    [Fact]
    public void Part1Test()
    {
        var sut = new RaceDay(lines);
        Assert.Equal(288, sut.Part1);
    }

    [Fact]
    public void Part2Test()
    {
        var sut = new RaceDay(lines);
        Assert.Equal(71503, sut.Part2);
    }
}