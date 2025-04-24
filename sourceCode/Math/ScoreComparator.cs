
public class ScoreComparator : IComparer<ScoreObject>
{
    public int Compare(ScoreObject? x, ScoreObject? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return x.Score.CompareTo(y.Score);
    }
}