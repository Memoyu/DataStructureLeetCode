namespace 排序算法._3.堆排序;

public class HeapSort<T> : BaseSort<T> where T : IComparable<T>
{
    private int _heapSize;

    protected override void Sort()
    {
        _heapSize = array.Length;

        // 先进行原地批量建堆
        // 根据二叉堆的【自上而下的下滤】可知需要进行下滤的元素只有非叶子节点；
        // 且根据完全二叉树性质，可得非叶子节点个数为 _heapSize / 2 = _heapSize >> 1，则最后一个元素为(_heapSize >> 1) - 1；
        for (int i = (_heapSize >> 1) - 1; i >= 0; i--)
        {
            SiftDown(i);
        }

        // 当剩下最后一个元素时，标识排序完成
        while (_heapSize > 1)
        {
            // 交换堆顶元素和尾部元素，并减少对大小，过滤已排序元素
            Swap(0, --_heapSize);
            // 对0位置进行SiftDown（恢复堆的性质）
            SiftDown(0);
        }
    }

    /// <summary>
    /// 对堆进行下虑操作
    /// </summary>
    /// <param name="index"></param>
    private void SiftDown(int index)
    {
        T value = array[index];
        var half = (_heapSize >> 1);
        while (index < half)
        {
            var childIndex = (index << 1) + 1;
            var child = array[childIndex];

            var rightIndex = childIndex + 1;
            if (rightIndex < _heapSize &&
                child.CompareTo(array[rightIndex]) < 0)
            {
                childIndex = rightIndex;
                child = array[childIndex];
            }

            if (value.CompareTo(array[childIndex]) >= 0) break;

            array[index] = child;
            index = childIndex;
        }

        array[index] = value;
    }
}