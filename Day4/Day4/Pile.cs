public class Pile
{
    readonly ArraySegment<Card> _cards;

    public Pile(string[] lines)
    {
        _cards = new (lines.Select(l => new Card(l)).ToArray());
    }

    public int SumWinningCards => _cards.Select(c => c.Score).Sum();

    public int CountTotalCards => _cards.Sum(CountCards);

    int CountCards(Card c) => c switch
    {
        { WinCount: 0 } => 1,
        _ => _cards.Slice(c.CardNumber, c.WinCount).Sum(CountCards) + 1
    };
}