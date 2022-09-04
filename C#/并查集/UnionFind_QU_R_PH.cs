namespace 并查集;

/// <summary>
/// 并查集 - Quick Union 基于rank(树高)且进行路径减半(Path Spliting)的优化实现方式
/// </summary>
public class UnionFind_QU_R_PH : UnionFind_QU_R
{
    public UnionFind_QU_R_PH(int capacity) : base(capacity)
    {
    }

    public override int Find(int v)
    {
        // 找根节点的同时，不断的让节点的父节点指向其祖父节点
        while (v != parents[v])
        {
            // 首行代码已经将parents[v]进行了赋值；
            // 例如，数组中有 1，2，3，4，5，6，7，如果v=1，则parents[v] = 2，而parents[parents[v]] = 3，执行完成后parents[v] = 3
            parents[v] = parents[parents[v]];
            v = parents[v];
        }

        return v;
    }
}