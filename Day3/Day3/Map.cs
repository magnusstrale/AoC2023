using Microsoft.VisualBasic;

public class Map
{
    string[] _map;
    int _maxCol;
    int _maxRow;

    public Map(string[] lines)
    {
        _map = lines;
        _maxCol = lines[0].Length;
        _maxRow = lines.Length;
    }

    public int SumEngineParts()
    {
        var sum = 0;
        for (var row = 0; row < _maxRow; row++)
        {
            var col = 0;
            while (col < _maxCol)
            {
                if (TryNumber(row, col, out var endCol) && AdjacentSymbol(row, col, endCol))
                    sum += int.Parse(_map[row][col..endCol]);
                col = endCol;
            }
        }
        return sum;
    }

    public bool TryNumber(int row, int col, out int endCol)
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
}