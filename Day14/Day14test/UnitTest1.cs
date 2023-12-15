namespace Day14test;

public class UnitTest1
{
    string[] lines = {
"O....#....",
"O.OO#....#",
".....##...",
"OO.#O....O",
".O.....O#.",
"O.#..O.#.#",
"..O..#O..O",
".......O..",
"#....###..",
"#OO..#...."
    };

    [Fact]
    public void TestPart1()
    {
        var sut = new Platform(lines);
        sut.TiltNorth();
        Assert.Equal(136, sut.LoadOnNorthBeams(sut.Map));
    }

    [Fact]
    public void TestPart2()
    {
        var sut = new Platform(lines);
        Assert.Equal(64, sut.LoadAfterManyCycles());
    }
}