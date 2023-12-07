namespace Day7test;

public class UnitTest1
{
    string[] lines = {
        "32T3K 765",
        "T55J5 684",
        "KK677 28",
        "KTJJT 220",
        "QQQJA 483"
    };

    [Theory]
    [InlineData("32T3K", HandType.OnePair)]
    [InlineData("T55J5", HandType.ThreeOfAKind)]
    [InlineData("KK677", HandType.TwoPair)]
    [InlineData("QQQJA", HandType.ThreeOfAKind)]
    [InlineData("QQAQA", HandType.FullHouse)]
    [InlineData("QQAQQ", HandType.FourOfAKind)]
    [InlineData("33333", HandType.FiveOfAKind)]
    [InlineData("TK248", HandType.HighCard)]
    public void HandTypeTest(string cards, HandType expected)
    {
        var sut = new Hand(cards, 0);
        Assert.Equal(expected, sut.Type);
    }
    
    [Fact]
    public void Part1Test()
    {
        var sut = new Game(lines);
        Assert.Equal(6440, sut.TotalWinnings);
    }

    [Fact]
    public void Part2Test()
    {
        var sut = new Game(lines);
        var x = sut.Hands.Select(h => new JokerHand(h.Cards, h.Bet)).Order().ToArray();
        Assert.Equal(5905, sut.JokerTotalWinnings);
    }
}