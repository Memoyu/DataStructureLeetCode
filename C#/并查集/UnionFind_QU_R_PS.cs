namespace 并查集;

/// <summary>
/// 并查集 - Quick Union 基于rank(树高)且进行路径分裂 (Path Spliting)的优化实现方式
/// </summary>
public class UnionFind_QU_R_PS : UnionFind_QU_R
{
    public UnionFind_QU_R_PS(int capacity) : base(capacity)
    {
    }

    public override int Find(int v)
    {
        RangeCheck(v);
        
        // 找根节点的同时，不断的让节点的父节点指向其祖父节点
        while (v != parents[v])
        {
            var parent = parents[v];
            parents[v] = parents[parent];
            v = parent;
        }

        return v;
    }
}