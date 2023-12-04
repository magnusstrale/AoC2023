public class Pile
{
    readonly Card[] _cards;

    public Pile(string[] lines)
    {
        _cards = lines.Select(l => new Card(l)).ToArray();
    }

    public int SumWinningCards =>
        _cards.Select(c => c.Score).Sum();

    public int CountTotalCards =>
        _cards.Sum(CountCards);

    int CountCards(Card c)
    {
        if (c.WinCount == 0) return 1;
        var cardsWon = _cards[c.CardNumber..(c.CardNumber + c.WinCount)];
        return cardsWon.Sum(CountCards) + 1;
    }
}