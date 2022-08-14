namespace 二叉堆;

public class BinaryHeap<T> : Heap<T> where T : IComparable<T>
{
    private T[] _array;

    private int _size;

    public BinaryHeap()
    {
        _array = new T [10];
    }

    public int Size()
    {
        return _size;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public void Clear()
    {
        for (int i = 0; i < _size; i++)
        {
            _array[i] = default(T);
        }

        _size = 0;
    }

    public void Add(T value)
    {
        // 空值检查
        ValueNotNullCheck(value);
        // 数组扩容
        EnsureCapacity(_size + 1);
        // 将新元素添加到数组的末尾
        _array[_size++] = value;
        // 进行上滤
        SiftUp(_size - 1);
    }

    public T Get()
    {
        EmptyCheck();
        return _array[0];
    }

    public T Remove()
    {
        throw new NotImplementedException();
    }

    public T Replace(T value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 上滤操作
    /// 从开始索引起，一直往上进行比对，比index对应的值还要小时，则进行值位置交换，否则大于或到达根节点时终止上滤
    /// </summary>
    /// <param name="index">上滤开始索引</param>
    private void SiftUp(int index)
    {
        // 备份开始上滤的值
        T value = _array[index];
        
        // 达到根节点，结束循环
        while (index > 0)
        {
            // 获取index索引对应的父节点索引
            int parentIndex = (index - 1) >> 1;
            var parentValue = _array[parentIndex];
            // 如果value 小于 parentValue 则结束 循环
            if (value.CompareTo(parentValue) >= 0) return;
            // 交换两个节点的值
            (_array[index], _array[parentIndex]) = (_array[parentIndex], _array[index]);
            // 重新赋值index
            index = parentIndex;
        }
    }

    /// <summary>
    /// 堆是否为空校验
    /// </summary>
    /// <exception cref="IndexOutOfRangeException"></exception>
    private void EmptyCheck()
    {
        if (_size == 0) throw new IndexOutOfRangeException("Heap is empty");
    }

    /// <summary>
    /// 值是否为空校验
    /// </summary>
    /// <param name="value">传入值</param>
    private void ValueNotNullCheck(T? value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value), "Value must not be null");
    }

    /// <summary>
    /// 判断当前size，决定是否进行扩容
    /// </summary>
    /// <param name="cap">当前需要的容量</param>
    private void EnsureCapacity(int cap)
    {
        int oldCap = _array.Length;
        if (oldCap >= cap) return;

        // 否则将容量提高为当前的1.5倍 (oldCap >> 1) 为 oldCap 右移 1 位，等同于 oldCap / 2 
        int newCap = oldCap + (oldCap >> 1);
        T[] newArray = new T[newCap];
        for (int i = 0; i < _array.Length; i++)
        {
            newArray[i] = _array[i];
        }

        _array = newArray;
    }
}