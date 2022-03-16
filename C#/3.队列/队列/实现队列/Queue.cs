namespace 队列.实现队列;

/// <summary>
/// 队列 使用LinkedList作为底层实现；
/// 从队尾入队，从对头出队；
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>
{
    private LinkedList<T> _linkedlist = new LinkedList<T>();

    /// <summary>
    /// 队列元素数量
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return _linkedlist.Count;
    }

    /// <summary>
    /// 队列是否为空
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return _linkedlist.Count <= 0;
    }

    /// <summary>
    /// 入队
    /// </summary>
    /// <param name="element"></param>
    public void EnQueue(T element)
    {
        _linkedlist.AddLast(element);
    }

    /// <summary>
    /// 出队
    /// </summary>
    /// <returns></returns>
    public T DeQueue()
    {
        var front = _linkedlist.First;
        _linkedlist.RemoveFirst();
        return front.Value;
    }

    /// <summary>
    ///  获取队列头
    /// </summary>
    /// <returns></returns>
    public T Front()
    {
        return (_linkedlist.First).Value;
    }

    /// <summary>
    /// 清除元素
    /// </summary>
    public void Clear()
    {
        _linkedlist.Clear();
    }
}
