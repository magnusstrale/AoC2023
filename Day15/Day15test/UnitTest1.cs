namespace Day15test;

public class UnitTest1
{
    string line = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";

    [Fact]
    public void TestPart1()
    {
        var sut = new InitializationManual(line);

        Assert.Equal(1320, sut.HashCodeSum);
    }

    [Fact]
    public void TestPart2()
    {
        var sut = new InitializationManual(line);

        Assert.Equal(145, sut.InterpretInstructions());
    }
}