namespace 并查集;

/// <summary>
/// 并查集 - Quick Find 基本实现方式
/// </summary>
public class UnionFind_QF : UnionFind
{
    public UnionFind_QF(int capacity) : base(capacity)
    {
    }

    /// <summary>
    /// 父节点就是根节点
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public override int Find(int v)
    {
        RangeCheck(v);
        
        // 直接获取v索引对应的值，该值则为根节点
        return parents[v];
    }

    /// <summary>
    /// 将v1所在集合的所有元素的父节点都指向v2的父节点
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    public override void Union(int v1, int v2)
    {
        var p1 = parents[v1];
        var p2 = parents[v2];
        if (p1 == p2) return;
        
        // 遍历所有的值，将 parents[i] == p1，即v1下的所有子节点；全部更新为p2，即parents[i] == p2
        for (int i = 0; i < parents.Length; i++)
        {
            if (parents[i] == p1)
            {
                parents[i] = p2;
            }
        }
    }
}