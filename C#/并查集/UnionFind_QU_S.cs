namespace 并查集;

/// <summary>
/// 并查集 - Quick Union 基于size(节点数量)的优化实现方式
/// </summary>
public class UnionFind_QU_S : UnionFind_QU
{
    private int[] _sizes;

    public UnionFind_QU_S(int capacity) : base(capacity)
    {
        _sizes = new int[parents.Length];
        for (int i = 0; i < _sizes.Length; i++)
        {
            _sizes[i] = 1;
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

        // 获取节点对应的size，size比较小的节合并到size较大的节点上
        if (_sizes[p1] < _sizes[p2])
        {
            parents[p1] = p2;
            // 更新size
            _sizes[p2] += _sizes[p1];
        }
        else
        {
            parents[p2] = p1;
            _sizes[p1] += _sizes[p2];
        }
    }
}