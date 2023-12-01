public class Calculator
{
    List<Game> _games;

    public Calculator(string[] lines)
    {
        _games = lines.Select(Game.Parse).ToList();
    }

    public int SumOfPossibleGames =>
        _games.Where(g => g.Possible(12, 13, 14)).Sum(g => g.Id);

    public int SumOfPowerOfMinimumCubes =>
        _games.Sum(g => g.PowerOfMinimumCubes());
}