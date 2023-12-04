public class Card
{
    public Card(string line)
    {
        var cardAndNumbers = line.Split(": ");
        CardNumber = int.Parse(cardAndNumbers[0][5..]);
        var numbers = cardAndNumbers[1].Split(" | ");
        var winningCards = ParseNumbers(numbers[0]);
        var myCards = ParseNumbers(numbers[1]);
        WinCount = myCards.Where(m => winningCards.Contains(m)).Count();
    }

    static int[] ParseNumbers(string nums) =>
        nums.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();

    public int Score => WinCount == 0 ? 0 : 1 << (WinCount - 1);

    public int WinCount { get; }

    public int CardNumber { get; }
}