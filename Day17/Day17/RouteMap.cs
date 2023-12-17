global using Pos = (int row, int col);
using System.Diagnostics;
public class RouteMap(string[] lines)
{
    public string[] Map { get; } = lines;
    public Pos LavaPool { get; } = (0, 0);
    public Pos Factory { get; } = (lines.Length - 1, lines[0].Length - 1);

    public int CrucibleMinimumHeatLoss => MinimumHeatLoss(0, 3);
    public int UltraCrucibleMinimumHeatLoss => MinimumHeatLoss(4, 10);

    int MinimumHeatLoss(int minStraight, int maxStraight)
    {
        var routes = new PriorityQueue<MapEntry, int>();
        var visited = new HashSet<(Pos, Direction, int)>();

        routes.Enqueue(new(LavaPool, Direction.Right, 0), 0);
        routes.Enqueue(new(LavaPool, Direction.Down, 0), 0);

        while (routes.Count > 0)
        {
            var input = routes.Dequeue();
            if (input.Position == Factory)
                return input.Heat;
            if (!TryMove(input.Position, input.Direction, out var current))
                continue;
            var totalHeat = input.Heat + Map[current.row][current.col] - '0';
            if (input.Steps < maxStraight)
            {
                Enqueue(new(current, input.Direction, totalHeat, input.Steps + 1));
            }
            if (input.Steps >= minStraight)
            {
                Enqueue(new(current, input.Direction.TurnLeft(), totalHeat));
                Enqueue(new(current, input.Direction.TurnRight(), totalHeat));
            }
        }
        throw new Exception("boom");

        void Enqueue(MapEntry entry)
        {
            var key = (entry.Position, entry.Direction, entry.Steps);
            if (visited.Contains(key)) return;
            visited.Add(key);
            routes.Enqueue(entry, entry.Heat);
        }
    }

    bool TryMove(Pos from, Direction direction, out Pos destination)
    {
        var delta = direction switch
        {
            Direction.Left => (0, -1),
            Direction.Right => (0, 1),
            Direction.Up => (-1, 0),
            Direction.Down => (1, 0),
            _ => throw new Exception("boom")
        };
        destination = (row: from.row + delta.Item1, col: from.col + delta.Item2);
        return destination.row >= 0 && destination.row <= Factory.row && destination.col >= 0 && destination.col <= Factory.col;
    }
}