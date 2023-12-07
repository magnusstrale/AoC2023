public enum HandType
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind
}

public record Hand(string Cards, int Bet) : IComparable<Hand>
{
    const string _strength = "23456789TJQKA";

    public virtual int Strength(char c) => _strength.IndexOf(c);

    public virtual HandType Type =>
        TypeFromCardCounts(Cards
            .Distinct()
            .Select(c => Cards.Count(crd => crd == c))
            .OrderDescending()
            .ToArray());

    protected static HandType TypeFromCardCounts(IList<int> counts) =>
        counts switch
        {
            [5] => HandType.FiveOfAKind,
            [4, 1] => HandType.FourOfAKind,
            [3, 2] => HandType.FullHouse,
            [3, 1, 1] => HandType.ThreeOfAKind,
            [2, 2, 1] => HandType.TwoPair,
            [2, 1, 1, 1] => HandType.OnePair,
            _ => HandType.HighCard
        };

    public int CompareTo(Hand? other)
    {
        if (other == null) return 1;
        var xt = Type;
        var yt = other.Type;
        if (xt == yt)
        {
            for (int i = 0; i < 5; i++)
            {
                var xs = Strength(Cards[i]);
                var ys = Strength(other.Cards[i]);
                if (xs == ys) continue;
                return xs - ys;
            }
            return 0;
        }
        return xt - yt;
    }
}