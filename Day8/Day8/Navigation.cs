public class Navigation
{
    int _directionIndex;

    public Navigation(string[] lines)
    {
        Directions = lines[0];
        Network = lines[2..].Select(l => ParseNode(l)).ToDictionary(n => n.Name);
    }

    Node ParseNode(string line)
    {
        var nameAndRest = line.Split(" = ");
        var left = nameAndRest[1][1..4];
        var right = nameAndRest[1][6..9];
        return new(nameAndRest[0], left, right);
    }

    public string Directions { get; }

    public Dictionary<string, Node> Network { get; }

    public long StepsToFinish =>
        StepsUntil(Network["AAA"], n => n.Name == "ZZZ");

    public long GhostStepsToFinish =>
        Network
            .Where(kv => kv.Key.EndsWith('A'))
            .Select(kv => StepsUntil(kv.Value, n => n.Name.EndsWith('Z')))
            .Aggregate(1L, LCM);

    static long LCM(long x, long y)
    {
        var product = x * y;
        while (x != y)
        {
            if (x > y)
                x -= y;
            else
                y -= x;
        }
        return product / x;
    }

    public long StepsUntil(Node startNode, Func<Node, bool> exitCondition)
    {
        var steps = 0L;
        var node = startNode;
        ResetDirection();
        while (!exitCondition(node))
        {
            steps++;
            node = Move(node);
        }
        return steps;
    }

    public Node Move(Node n) =>
        Network[GetDirectionAndAdvance() == 'L' ? n.Left : n.Right];

    char GetDirectionAndAdvance()
    {
        var d = Directions[_directionIndex++];
        if (_directionIndex == Directions.Length) _directionIndex = 0;
        return d;
    }

    void ResetDirection()
    {
        _directionIndex = 0;
    }
}