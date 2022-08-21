namespace 二叉堆;

public class BinaryHeap<T> : Heap<T> where T : IComparable<T>
{
    private T[] _array;

    private int _size;

    public BinaryHeap()
    {
        _array = new T [10];
    }
    
    public BinaryHeap(T []? values)
    {
        if (values == null || values.Length == 0)
        {
            _array = new T [10];
        }
        else
        {
            // 将数据迁移到堆中
            _array = new T[values.Length];
            _size = values.Length;
            for (int i = 0; i < values.Length; i++)
            {
                _array[i] = values[i];
            }
            Heapify();
        }
        
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
            _array[i] = default;
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
        // 校验堆是否为空
        EmptyCheck();
        // 返回堆顶
        return _array[0];
    }

    public T Remove()
    {
        // 校验堆是否为空
        EmptyCheck();
        // 获取堆顶元素
        T root = _array[0];
        var lastIndex = --_size;
        // 覆盖堆顶元素
        _array[0] = _array[lastIndex];
        // 删除最后一个元素
        _array[lastIndex] = default;
        // 进行下滤操作
        SiftDown(0);

        return root;
    }

    public T Replace(T value)
    {
        // 检查值是否为null
        ValueNotNullCheck(value);

        T root = default;
        if (_size == 0)
        {
            _array[0] = value;
            _size++;
        }
        else
        {
            root = _array[0];
            _array[0] = value;
            SiftDown(0);
        }

        return root;
    }

    private void Heapify()
    {
        // 进行原地批量建堆
        // 根据二叉堆的【自上而下的下滤】可知需要进行下滤的元素只有非叶子节点；
        // 且根据完全二叉树性质，可得非叶子节点个数为 _size / 2 = _size >> 1，则最后一个元素为(_size >> 1) - 1；
        for (int i = (_size >> 1) - 1 ; i >= 0; i--)
        {
            SiftDown(i);
        }
    }

    /// <summary>
    /// 上滤操作
    /// 从开始索引index起，一直往下进行比对，子节点中最大的值比index对应的值大时，则与最大的节点进行位置交换，否则小于或到没有子节点时终止下滤
    /// </summary>
    /// <param name="index"></param>
    private void SiftDown(int index)
    {
        // 获取index对应的值
        T value = _array[index];
        // 获取第一个叶子节点的索引，因为只有当index为非叶子节点时，才需要进行下滤
        // 利用完全二叉树的性质可知，非叶子节点数为 floor(n / 2)，代码中可省略floor，参考：https://www.yuque.com/memoyu/ezn2kr/tvew68
        var half = _size >> 1; // 等价于 _size / 2
        while (index < half)
        {
            // 默认左子节点最大，将其取出
            int childIndex = (index << 1) + 1; // 由完全二叉树性质可得index左子节点为 (index * 2) + 1 = (index << 1) + 1
            var child = _array[childIndex];
            
            // 将child与右子节点比较，比左子节点大时，则将右子节点赋值给child
            var rightIndex = childIndex + 1; // 由完全二叉树性质可得index左子节点为 (index * 2) + 1 = (index << 1) + 1
            // 算出的右子节点索引是否在_size内，并且值是否大于左子节点
            if (rightIndex < _size 
                && child.CompareTo(_array[rightIndex]) > 0)
            {
                
                childIndex = rightIndex;
                child = _array[childIndex];
            }

            if (value.CompareTo(child) >= 0) break;

            _array[index] = child;
            index = childIndex;
        }
        
        // 将值赋值给最终下滤的索引
        _array[index] = value;
    }
    
    /// <summary>
    /// 上滤操作
    /// 从开始索引index起，一直往上进行比对，根节点比index对应的值还要小时，则进行位置交换，否则大于或到达根节点时终止上滤
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
            if (value.CompareTo(parentValue) >= 0) break;
            // 将父元素的值直接存入index位置
            _array[index] = parentValue;
            // 重新赋值index
            index = parentIndex;
        }

        // 将 value 放到最终index位置，完成上滤
        _array[index] = value;
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