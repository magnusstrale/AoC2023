public record JokerHand(string Cards, int Bet) : Hand(Cards, Bet)
{
    const string _strength = "J23456789TQKA";
    
    public override int Strength(char c) => _strength.IndexOf(c);

    public override HandType Type 
    {
        get 
        {
            var counts = Cards
                .Distinct()
                .Where(c => c != 'J')
                .Select(c => Cards.Count(crd => crd == c))
                .OrderDescending()
                .ToList();
            var nonJokers = counts.Sum();
            if (nonJokers == 0) counts.Add(0);
            counts[0] += 5 - nonJokers;
            return TypeFromCardCounts(counts);
        }
    }
}