namespace Day12test;

public class UnitTest1
{
    string[] lines =
    {
        "???.### 1,1,3",
        ".??..??...?##. 1,1,3",
        "?#?#?#?#?#?#?#? 1,3,1,6",
        "????.#...#... 4,1,1",
        "????.######..#####. 1,6,5",
        "?###???????? 3,2,1"
    };

    [Fact]
    public void TestPart1()
    {
        var sut = new Solver(lines);
        Assert.Equal(21, sut.CountPossibleArrangements);
    }

    [Fact]
    public void TestPart2()
    {
        var sut = new Solver(lines);
        Assert.Equal(525152, sut.CountExpandedArrangements);
    }
}