global using CMap = char[][];

using System.Data;
using System.Diagnostics;



public class Platform
{

    MapHistory _history;
    public CMap Map;

    public Platform(string[] lines)
    {
        Map = lines.Select(l => l.ToArray()).ToArray();
        _history = new();
    }

    public void TiltNorth()
    {
        var movement = true;
        while (movement)
        {
            movement = false;
            for (var row = 0; row < Map.Length - 1; row ++)
            {
                for (var col = 0; col < Map[row].Length; col ++)
                {
                    if (Map[row][col] == '.' && Map[row + 1][col] == 'O')
                    {
                        movement = true;
                        Map[row][col] = 'O';
                        Map[row + 1][col] = '.';
                    }
                }
            }
        }
    }

    public void TiltSouth()
    {
        var movement = true;
        while (movement)
        {
            movement = false;
            for (var row = Map.Length - 1; row > 0; row--)
            {
                for (var col = 0; col < Map[row].Length; col ++)
                {
                    if (Map[row][col] == '.' && Map[row - 1][col] == 'O')
                    {
                        movement = true;
                        Map[row][col] = 'O';
                        Map[row - 1][col] = '.';
                    }
                }
            }
        }
    }

    public void TiltWest()
    {
        var movement = true;
        while (movement)
        {
            movement = false;
            for (var row = 0; row < Map.Length; row++)
            {
                for (var col = 0; col < Map[row].Length - 1; col ++)
                {
                    if (Map[row][col] == '.' && Map[row][col + 1] == 'O')
                    {
                        movement = true;
                        Map[row][col] = 'O';
                        Map[row][col + 1] = '.';
                    }
                }
            }
        }
    }

    public void TiltEast()
    {
        var movement = true;
        while (movement)
        {
            movement = false;
            for (var row = 0; row < Map.Length; row++)
            {
                for (var col = Map[row].Length - 1; col > 0; col--)
                {
                    if (Map[row][col] == '.' && Map[row][col - 1] == 'O')
                    {
                        movement = true;
                        Map[row][col] = 'O';
                        Map[row][col - 1] = '.';
                    }
                }
            }
        }
    }

    public void Cycle()
    {
        TiltNorth();
        TiltWest();
        TiltSouth();
        TiltEast();
    }

    public int LoadAfterManyCycles()
    {
        var cycle = 0;
        var stepsBack = 0;
        while ((stepsBack = _history.PreviousMap(Map)) == -1)
        {
            _history.Add(Map);
            Cycle();
            cycle ++;
        }
        var i = ((1_000_000_000L - cycle) % stepsBack);
        return LoadOnNorthBeams(_history.Map((int)i + cycle - stepsBack));
    }

    public int LoadOnNorthBeams(CMap map)
    {
        var load = 0;
        var weight = map.Length;
        foreach (var row in map)
        {
            load += weight * row.Count(c => c == 'O');
            weight --;
        }
        return load;
    }


    public void PrintMap(int cycle)
    {

        foreach (var row in Map)
        {
            Debug.WriteLine(new string(row));
        }
        Debug.WriteLine("---- Cycle " + cycle + " load " + LoadOnNorthBeams(Map));
    }
}