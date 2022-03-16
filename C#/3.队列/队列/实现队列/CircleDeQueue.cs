using System.Text;

namespace 队列.实现队列;

public class CircleDeQueue<T>
{
    private const int _initSize = 10;
    private int _front;
    private int _size;
    private T[] _arrary;

    public CircleDeQueue()
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
    /// 队尾入队
    /// </summary>
    /// <param name="element"></param>
    public void EnQueueRear(T element)
    {
        EnsureCapacity(_size + 1);
        _arrary[Index(_size)] = element;
        _size++;
    }

    /// <summary>
    /// 队头入队
    /// </summary>
    /// <param name="element"></param>
    public void EnQueueFront(T element)
    {
        EnsureCapacity(_size + 1);

        // 因为是对头入队，所以队头指针需要更新，且是对头前一个入队，所以下标为当前对头-1，故传入-1
        _front = Index(-1);
        _arrary[_front] = element;
        _size++;
    }

    /// <summary>
    /// 队尾出队
    /// </summary>
    /// <returns></returns>
    public T DeQueueRear()
    {
        // 正常数组下，最后一个元素的下标时size - 1（数组是连续的存储），此处多了一个取模
        var rearIndex = Index(_size - 1);
        var front = _arrary[rearIndex];
        _arrary[rearIndex] = default;
        _size--;
        return front;
    }

    /// <summary>
    /// 队头出队
    /// </summary>
    /// <returns></returns>
    public T DeQueueFront()
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
    ///  获取队列尾
    /// </summary>
    /// <returns></returns>
    public T Rear()
    {
        return _arrary[Index(_size - 1)];
    }

    /// <summary>
    /// 清除元素
    /// </summary>
    public void Clear()
    {
        for (int i = 0; i < _size; i++)
        {
            _arrary[Index(i)] = default;
        }

        _size = 0;
        _front = 0;
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
        // 这里主要防止出现_front + index < 0的情况，因为队头入队可能会导致出现负数的情况
        // 非负数时，取模，完成映射获取到数组下标
        //   负数时，直接返回负数加上数组容量得到数组下标
        index += _front;
        return index < 0 ? (index + _arrary.Length) : index % _arrary.Length;
    }
}
