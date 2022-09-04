namespace 二叉堆;

public interface IHeap<T> where T : IComparable<T>
{
    /// <summary>
    /// 元素的数量
    /// </summary>
    /// <returns></returns>
    int Size();
    
    /// <summary>
    /// 是否为空
    /// </summary>
    /// <returns></returns>
    bool IsEmpty();
    
    /// <summary>
    /// 清空
    /// </summary>
    void Clear();
    
    /// <summary>
    /// 添加元素
    /// </summary>
    /// <param name="value">节点值</param>
    void Add(T value);
    
    /// <summary>
    /// 获得堆顶元素
    /// </summary>
    /// <returns></returns>
    T Get();
    
    /// <summary>
    /// 删除堆顶元素
    /// </summary>
    /// <returns></returns>
    T Remove();
    
    /// <summary>
    /// 删除堆顶元素的同时插入一个新元素
    /// </summary>
    /// <param name="value">节点值</param>
    /// <returns></returns>
    T Replace(T value);
}