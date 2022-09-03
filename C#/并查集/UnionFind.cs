namespace 并查集;

public abstract class UnionFind
{
    protected int[] parents;

    public UnionFind(int capacity)
    {
        if (capacity < 0) throw new ArgumentException("容量必须大于0");
        parents = new int[capacity];
        for (int i = 0; i < parents.Length; i++)
        {
            parents[i] = i;
        }
    }

    /// <summary>
    /// 查找v所属的集合（根节点）
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public abstract int Find(int v);

    /// <summary>
    /// 合并v1、v2所在的集合
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    public abstract void Union(int v1, int v2);

    /// <summary>
    /// 检查v1、v2是否属于同一个集合(根节点是否相同)
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    public bool IsSame(int v1, int v2)
    {
        return Find(v1) == Find(v2);
    }

    protected void RangeCheck(int v)
    {
        if (v < 0 || v >= parents.Length)
        {
            throw new Exception("v is out of bounds");
        }
    }
}