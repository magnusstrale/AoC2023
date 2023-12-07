using System.Numerics;

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

    public int StepsToFinish()
    {
        var current = Network["AAA"];
        var steps = 0;
        ResetDirection();
        while (current.Name != "ZZZ")
        {
            steps++;
            current = Move(current);
        }
        return steps;
    }

    public long GhostStepsToFinish()
    {
        var ghostNodes = Network.Where(kv => kv.Key.EndsWith('A')).Select(kv => kv.Value).ToArray();
        var ghostSteps = new List<long>();
        foreach (var ghostNode in ghostNodes)
        {
            var steps = 0;
            ResetDirection();
            var node = ghostNode;
            while (!node.Name.EndsWith('Z'))
            {
                steps++;
                node = Move(node);
            }
            ghostSteps.Add(steps);
        }

        return ghostSteps.Aggregate(1L, LCM);
    }

    static long LCM(long x, long y)
    {
        var num1 = x;
        var num2 = y;
        while (num1 != num2)
        {
            if (num1 > num2)
                num1 -= num2;
            else
                num2 -= num1;
        }
        return (x * y) / num1;
    }

    public char GetDirectionAndAdvance()
    {
        var d = Directions[_directionIndex++];
        if (_directionIndex == Directions.Length) _directionIndex = 0;
        return d;
    }

    public void ResetDirection()
    {
        _directionIndex = 0;
    }

    public Node Move(Node n) =>
        Network[GetDirectionAndAdvance() == 'L' ? n.Left : n.Right];

}