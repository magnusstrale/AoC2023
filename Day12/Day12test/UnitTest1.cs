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

    [Theory]
    [InlineData("???.### 1,1,3", "#.#.###", true)]
    [InlineData("???.### 1,1,3", "..#.###", false)]
    [InlineData("???.### 1,1,3", "#..####", false)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", ".#.###.#.######", true)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", ".#.#####.##.###", false)]
    public void TestIsValid(string line, string cond, bool expected)
    {
        var sut = new Record(line);
        Assert.Equal(expected, sut.IsValid(cond));
    }

    [Fact]
    public void TestPart1()
    {
        var sut = new Solver(lines);
        Assert.Equal(21, sut.CountPossibleArrangements);
    }
}