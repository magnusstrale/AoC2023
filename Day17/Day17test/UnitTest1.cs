namespace Day17test;

public class UnitTest1
{
    public string[] lines = [
        "2413432311323",
        "3215453535623",
        "3255245654254",
        "3446585845452",
        "4546657867536",
        "1438598798454",
        "4457876987766",
        "3637877979653",
        "4654967986887",
        "4564679986453",
        "1224686865563",
        "2546548887735",
        "4322674655533"
    ];

    [Fact]
    public void TestPart1()
    {
        var sut = new RouteMap(lines);
        Assert.Equal(102, sut.CrucibleMinimumHeatLoss);
    }
    [Fact]
    public void TestPart2()
    {
        var sut = new RouteMap(lines);
        Assert.Equal(94, sut.UltraCrucibleMinimumHeatLoss);
    }
}