public class Box(int boxNumber)
{
    List<Lens> Lenses { get; } = [];

    int BoxNumber { get; } = boxNumber;

    public void RemoveLens(string label) => TryAction(label, i => Lenses.RemoveAt(i));

    public void InsertOrReplace(Lens lens)
    { 
        if (!TryAction(lens.Label, i => Lenses[i] = lens)) Lenses.Add(lens);
    }

    public long FocalPower => Enumerable.Range(0, Lenses.Count).Select(l => (BoxNumber + 1) * (l + 1) * Lenses[l].FocalLength).Sum();

    bool TryAction(string label, Action<int> act)
    {
        for (var i = 0; i < Lenses.Count; i++)
        {
            if (Lenses[i].Label == label)
            {
                act(i);
                return true;
            }
        }
        return false;
    }
}