namespace 并查集;

/// <summary>
/// 并查集 - Quick Union 实现方式
/// </summary>
public class UnionFind_QU : UnionFind
{
    public UnionFind_QU(int capacity) : base(capacity)
    {
    }

    public override int Find(int v)
    {
        RangeCheck(v);
        while (v != parents[v])
        {
            v = parents[v];
        }
        
        return v;
    }

    public override void Union(int v1, int v2)
    {
        var p1 = parents[v1];
        var p2 = parents[v2];
        if (p1 == p2) return;
        parents[v1] = p2;
    }
}