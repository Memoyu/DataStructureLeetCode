namespace 并查集;

/// <summary>
/// 并查集 - Quick Union 基于rank(树高)且进行路径压缩(Path Compression)的优化实现方式
/// </summary>
public class UnionFind_QU_R_PC : UnionFind_QU_R
{
    public UnionFind_QU_R_PC(int capacity) : base(capacity)
    {
    }

    /// <summary>
    /// 在find的过程中，将find路径上所有节点直接指向根节点
    /// 此处会造成rank的不准确，所以这里的树高叫rank，而不叫height或者depth的原因
    /// 但是总体上不会出现a节点的高度比b节点高，但是a节点的rank却比b节点低的情况
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public override int Find(int v)
    {
        RangeCheck(v);
        // 只要没有找到根节点，则进行递归处理
        if (parents[v] != v)
        {
            // 将路径中的节点指向根节点
            parents[v] = Find(parents[v]);
        }

        return parents[v];
    }
}