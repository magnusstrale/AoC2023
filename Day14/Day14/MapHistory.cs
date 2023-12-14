public class MapHistory
{
    List<CMap> _history;

    public MapHistory() => _history = [];

    public void Add(CMap map)
    {
        var clone = new char [map.Length][];
        for (var r = 0; r < map.Length; r++)
            clone[r] = (char[])map[r].Clone();
        _history.Add(clone);
    } 

    public CMap Map(int i) => _history[i];
    
    public int PreviousMap(CMap map)
    {
        var steps = 0;
        foreach (var h in _history.Reverse<CMap>())
        {
            steps ++;
            if (MapEqual(h, map)) return steps;
        }
        return -1;
    }

    bool MapEqual(CMap x, CMap y)
    {
        for (var r = 0; r < x.Length; r ++)
        {
            for (var c = 0; c < x[r].Length; c++)
            {
                if (x[r][c] != y[r][c]) return false;
            }
        }
        return true;
    }
}