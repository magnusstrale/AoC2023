global using Pos = (int row, int col);
using System.Diagnostics;
using System.Security.Cryptography;

public class RouteMap
{
    public RouteMap(string[] lines)
    {
        Map = lines;
        LavaPool = (0, 0);
        Factory = (lines.Length - 1, lines[0].Length - 1);
    }

    public Pos LavaPool { get; }
    public Pos Factory { get; }
    public string[] Map { get; }

    public int MinimumHeatLoss()
    {
        var routes = new PriorityQueue<MapEntry, int>();
        var visited = new HashSet<(Pos, Direction, int)>();
        MapEntry here;

        routes.Enqueue(new(Position: LavaPool, Direction: Direction.Right), 0);
        routes.Enqueue(new(Position: LavaPool, Direction: Direction.Down), 0);

        while (routes.Count > 0)
        {
            here = routes.Dequeue();
            //PrintMap(here);

            if (!TryMove(here.Position, here.Direction, out var current))
                continue;

            var totalHeat = here.Heat + Map[current.row][current.col] - '0';
            if (here.Position == Factory)
                return here.Heat;

            if (here.Steps < 3)
            {
                Enqueue(visited, routes, new MapEntry(Position: current, Direction: here.Direction, Heat: totalHeat, Steps: here.Steps + 1));
            }
            Enqueue(visited, routes, new MapEntry(Position: current, Direction: TurnLeft(here.Direction), Heat: totalHeat));
            Enqueue(visited, routes, new MapEntry(Position: current, Direction: TurnRight(here.Direction), Heat: totalHeat));
        }
        throw new Exception("boom");
    }

    void PrintMap(MapEntry entry)
    {
        var rowCount = 0;
        foreach (var row in Map)
        {
            var colCount = 0;
            foreach (var col in row)
            {
                var c = col;
                if (entry.Position == (rowCount, colCount))
                {
                    c = entry.Direction switch 
                    {
                        Direction.Up => '^',
                        Direction.Down => 'v',
                        Direction.Left => '<',
                        Direction.Right => '>',
                        _ => throw new Exception("boom")
                    };
                }
                Debug.Write(c);
                colCount ++;
            }
            Debug.Write('\n');
            rowCount ++;
        }
        Debug.WriteLine("Heat - " + entry.Heat);
    }

    void Enqueue(HashSet<(Pos, Direction, int)> visited, PriorityQueue<MapEntry, int> queue, MapEntry entry)
    {
        var key = (entry.Position, entry.Direction, entry.Steps);
        if (visited.Contains(key)) return;
        visited.Add(key);
        queue.Enqueue(entry, entry.Heat);
    }

    bool ContainsEntry(PriorityQueue<MapEntry, int> queue, MapEntry entry) =>  (queue.UnorderedItems.Any(e => e.Element.Position == entry.Position && e.Element.Direction == entry.Direction && e.Element.Steps == entry.Steps));
    Direction TurnLeft(Direction direction) => direction switch
    {
        Direction.Up => Direction.Left,
        Direction.Down => Direction.Right,
        Direction.Left => Direction.Down,
        Direction.Right => Direction.Up,
        _ => throw new Exception("boom")
    };

    Direction TurnRight(Direction direction) => direction switch
    {
        Direction.Up => Direction.Right,
        Direction.Down => Direction.Left,
        Direction.Left => Direction.Up,
        Direction.Right => Direction.Down,
        _ => throw new Exception("boom")
    };

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