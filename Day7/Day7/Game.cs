public class Game
{
    public Game(string[] lines)
    {
        Hands = lines.Select(l => l.Split(' ')).Select(sl => new Hand(sl[0], int.Parse(sl[1]))).ToArray();
    }

    public Hand[] Hands {get;}

    public long TotalWinnings =>
        CalculateTotalWinnings(Hands);

    public long JokerTotalWinnings =>
        CalculateTotalWinnings(Hands.Select(h => new JokerHand(h.Cards, h.Bet)));

    long CalculateTotalWinnings(IEnumerable<Hand> hands) =>
        hands.Order().Zip(Enumerable.Range(1, Hands.Length)).Sum(tpl => tpl.First.Bet * tpl.Second);
}