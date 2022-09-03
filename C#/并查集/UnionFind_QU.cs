namespace 并查集;

/// <summary>
/// 并查集 - Quick Union 基本实现方式
/// </summary>
public class UnionFind_QU : UnionFind
{
    public UnionFind_QU(int capacity) : base(capacity)
    {
    }

    /// <summary>
    /// 通过parent链表不断地向上找，直到找到根节点
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public override int Find(int v)
    {
        RangeCheck(v);
        
        // 不断的向上找，直到索引等于索引对应的值（说明已经到达根节点）
        while (v != parents[v])
        {
            v = parents[v];
        }
        
        // 返回根节点
        return v;
    }

    /// <summary>
    /// 将v1的根节点指向v2的根节点
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    public override void Union(int v1, int v2)
    {
        var p1 = Find(v1);
        var p2 = Find(v2);
        if (p1 == p2) return;
        
        // 将 v1 的值变更为 p2 （则将 v1 的父节点 指向 v2 ）
        parents[p1] = p2;
    }
}