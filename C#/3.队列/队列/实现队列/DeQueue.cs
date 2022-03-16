namespace 队列.实现队列;

/// <summary>
/// 双端队列 仍然使用LinkedList作为底层实现；
/// </summary>
public class DeQueue<T>
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
    /// 队尾入队
    /// </summary>
    /// <param name="element"></param>
    public void EnQueueRear(T element)
    {
        _linkedlist.AddLast(element);
    }

    /// <summary>
    /// 队头入队
    /// </summary>
    /// <param name="element"></param>
    public void EnQueueFront(T element)
    {
        _linkedlist.AddFirst(element);
    }

    /// <summary>
    /// 队尾出队
    /// </summary>
    /// <returns></returns>
    public T DeQueueRear()
    {
        var rear = _linkedlist.Last;
        _linkedlist.RemoveLast();
        return rear.Value;
    }

    /// <summary>
    /// 队头出队
    /// </summary>
    /// <returns></returns>
    public T DeQueueFront()
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
    ///  获取队列尾
    /// </summary>
    /// <returns></returns>
    public T Rear()
    {
        return (_linkedlist.Last).Value;
    }

    /// <summary>
    /// 清除元素
    /// </summary>
    public void Clear()
    {
        _linkedlist.Clear();
    }
}