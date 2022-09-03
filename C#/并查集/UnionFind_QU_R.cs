namespace 并查集;

/// <summary>
/// 并查集 - Quick Union 基于rank(树高)的优化实现方式
/// </summary>
public class UnionFind_QU_R : UnionFind_QU
{
    private int[] _ranks;

    public UnionFind_QU_R(int capacity) : base(capacity)
    {
        _ranks = new int[parents.Length];
        for (int i = 0; i < _ranks.Length; i++)
        {
            _ranks[i] = 1;
        }
    }

    /// <summary>
    /// 将v1的根节点指向v2的根节点 - 基于size进行优化
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    public override void Union(int v1, int v2)
    {
        var p1 = Find(v1);
        var p2 = Find(v2);
        if (p1 == p2) return;

        // 获取节点对应的rank，rank比较小的节合并到rank较大的节点上
        // 只有树高相等时，合并后才需要增高树高
        if (_ranks[p1] < _ranks[p2])
        {
            parents[p1] = p2;
        }
        else if (_ranks[p1] > _ranks[p2])
        {
            parents[p2] = p1;
        }
        else
        {
            parents[p1] = p2;
            _ranks[p2]++;
        }
    }
}