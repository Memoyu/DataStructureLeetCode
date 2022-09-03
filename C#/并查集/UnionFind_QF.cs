namespace 并查集;

/// <summary>
/// 并查集 - Quick Find 实现方式
/// </summary>
public class UnionFind_QF : UnionFind
{
    public UnionFind_QF(int capacity) : base(capacity)
    {
    }

    public override int Find(int v)
    {
        RangeCheck(v);
        return parents[v];
    }

    public override void Union(int v1, int v2)
    {
        var p1 = parents[v1];
        var p2 = parents[v2];
        if (p1 == p2) return;
        for (int i = 0; i < parents.Length; i++)
        {
            if (parents[i] == p1)
            {
                parents[i] = p2;
            }
        }
    }
}