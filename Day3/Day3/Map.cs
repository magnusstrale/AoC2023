using Microsoft.VisualBasic;

public class Map
{
    string[] _map;
    int _maxCol;
    int _maxRow;
    Dictionary<(int, int), List<int>> _gearNumbers;

    public Map(string[] lines)
    {
        _map = lines;
        _maxCol = lines[0].Length;
        _maxRow = lines.Length;
        _gearNumbers = new();
    }

    public int SumGearRatio()
    {
        var sum = 0;
        for (var row = 0; row < _maxRow; row++)
        {
            var col = 0;
            while (col < _maxCol)
            {
                if (TryFindNumber(row, col, out var endCol))
                    AdjacentAsterisk(row, col, endCol);
                col = endCol;
            }
        }
        foreach (var l in _gearNumbers.Values)
        {
            if (l.Count == 2)
                sum += l[0] * l[1];
        }
        return sum;
    }

    public int SumEngineParts()
    {
        var sum = 0;
        for (var row = 0; row < _maxRow; row++)
        {
            var col = 0;
            while (col < _maxCol)
            {
                if (TryFindNumber(row, col, out var endCol) && AdjacentSymbol(row, col, endCol))
                    sum += int.Parse(_map[row][col..endCol]);
                col = endCol;
            }
        }
        return sum;
    }

    public bool TryFindNumber(int row, int col, out int endCol)
    {
        endCol = col + 1;
        var result = char.IsDigit(_map[row][col]);
        while (result && endCol < _maxCol && char.IsDigit(_map[row][endCol]))
            endCol++;
        return result;
    }

    public bool AdjacentSymbol(int row, int startCol, int endCol)
    {
        int rowFrom = int.Max(row - 1, 0);
        int rowTo = int.Min(row + 2, _maxRow);
        int colFrom = int.Max(startCol - 1, 0);
        int colTo = int.Min(endCol + 1, _maxCol);

        for (var r = rowFrom; r < rowTo; r++)
        {
            for (var c = colFrom; c < colTo; c++)
            {
                if (_map[r][c] != '.' && !char.IsDigit(_map[r][c]))
                    return true;
            }
        }
        return false;
    }

    public void AdjacentAsterisk(int row, int startCol, int endCol)
    {
        int rowFrom = int.Max(row - 1, 0);
        int rowTo = int.Min(row + 2, _maxRow);
        int colFrom = int.Max(startCol - 1, 0);
        int colTo = int.Min(endCol + 1, _maxCol);

        for (var r = rowFrom; r < rowTo; r++)
        {
            for (var c = colFrom; c < colTo; c++)
            {
                if (_map[r][c] == '*')
                {
                    if (!_gearNumbers.TryGetValue((r, c), out var l))
                    {
                        l = new();
                        _gearNumbers[(r, c)] = l;
                    }
                    l.Add(int.Parse(_map[row][startCol..endCol]));
                }
            }
        }
    }
}