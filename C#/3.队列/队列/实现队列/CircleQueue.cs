using System.Text;

namespace 队列.实现队列;

public class CircleQueue<T>
{
    private const int _initSize = 10;
    private int _front;
    private int _size;
    private T[] _arrary;

    public CircleQueue()
    {
        _arrary = new T[_initSize];
    }

    /// <summary>
    /// 队列元素数量
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return _size;
    }

    /// <summary>
    /// 队列是否为空
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return _size == 0;
    }

    /// <summary>
    /// 入队
    /// </summary>
    /// <param name="element"></param>
    public void EnQueue(T element)
    {
        EnsureCapacity(_size + 1);
        _arrary[Index(_size)] = element;
        _size++;
    }

    /// <summary>
    /// 出队
    /// </summary>
    /// <returns></returns>
    public T DeQueue()
    {
        var front = _arrary[_front];
        _arrary[_front] = default;
        _front = Index(1);
        _size--;
        return front;
    }

    /// <summary>
    ///  获取队列头
    /// </summary>
    /// <returns></returns>
    public T Front()
    {
        return _arrary[_front];
    }

    /// <summary>
    /// 清除元素
    /// </summary>
    public void Clear()
    {

    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Capacity={_arrary.Length}")
            .Append($" Size={_size}")
            .Append($" Front={_front}").Append(" [");

        for (int i = 0; i < _arrary.Length; i++)
        {
            if (i != 0)
                sb.Append(", ");
            sb.Append(_arrary[i]);
        }
        sb.Append(" ]");
        return sb.ToString();
    }

    /// <summary>
    /// 底层数组动态扩容
    /// </summary>
    /// <param name="size"></param>
    private void EnsureCapacity(int size)
    {
        int oldCapacity = _arrary.Length;
        if (oldCapacity >= size) return;
        
        // 这里设置新的容量为旧的容量的1.5倍
        int newCapacity = oldCapacity + (oldCapacity >> 1);
        T[] newArray = new T[newCapacity];
        for (int i = 0; i < _size; i++)
        {
            newArray[i] = _arrary[Index(i)];// 从队头开始进行新数组迁移，i=0时，则是对头，Index()则是获取此时0在循环数组中的真是下标
        }
        _arrary = newArray;
        _front = 0;
    }


    /// <summary>
    /// 获取循环数组的真实下标
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private int Index(int index)
    {
        return (_front + index) % _arrary.Length;
    }
}
