global using CMap = char[][];

using System.Data;
using System.Diagnostics;

public class Platform(string[] lines)
{
    MapHistory History { get; } = new();

    public CMap Map = lines.Select(l => l.ToArray()).ToArray();

    public void TiltNorth() => Tilt(1, 0);

    void Tilt(int rowOffset, int colOffset)
    {
        int OffsetToStart(int offset) => offset == -1 ? 1 : 0;
        int OffsetToEnd(int offset) => offset == 1 ? 1 : 0;

        var movement = true;
        while (movement)
        {
            movement = false;
            for (var row = OffsetToStart(rowOffset); row < Map.Length - OffsetToEnd(rowOffset); row ++)
            {
                for (var col = OffsetToStart(colOffset); col < Map[row].Length - OffsetToEnd(colOffset); col ++)
                {
                    if (Map[row][col] == '.' && Map[row + rowOffset][col + colOffset] == 'O')
                    {
                        movement = true;
                        Map[row][col] = 'O';
                        Map[row + rowOffset][col + colOffset] = '.';
                    }
                }
            }
        }
    }

    void Cycle()
    {
        foreach ((var rowOffset, var colOffset) in new [] {(1,0), (0, 1), (-1, 0), (0, -1)})
        {
            Tilt(rowOffset, colOffset);
        }
    }

    public int LoadAfterManyCycles()
    {
        var cycle = 0;
        int stepsBack;
        while ((stepsBack = History.PreviousMap(Map)) == -1)
        {
            History.Add(Map);
            Cycle();
            cycle ++;
        }
        var i = (1_000_000_000L - cycle) % stepsBack;
        return LoadOnNorthBeams(History.Map((int)i + cycle - stepsBack));
    }

    public static int LoadOnNorthBeams(CMap map) => Enumerable.Range(1, map.Length).Reverse().Zip(map).Sum(p => p.First * p.Second.Count(c => c == 'O'));
}