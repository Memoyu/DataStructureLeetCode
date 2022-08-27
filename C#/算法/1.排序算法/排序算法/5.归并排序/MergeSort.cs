namespace 排序算法._5.归并排序;

public class MergeSort<T> : BaseSort<T> where T : IComparable<T>
{
    private T[] _leftArray;

    protected override void Sort()
    {
        _leftArray = new T[array.Length >> 1];
        Sort(0, array.Length);
    }

    /// <summary>
    /// 对指定范围 [begin, end) 的数据进行排序
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    private void Sort(int begin, int end)
    {
        // 当范围内的元素仅剩一个或者是没有时，则不进行操作
        if (end - begin < 2) return;
        var mid = (begin + end) >> 1;
        Sort(begin, mid);
        Sort(mid, end);
        Merge(begin, mid, end);
    }

    /// <summary>
    /// 对指定范围 [begin, mid) （左） 和 [mid, end) （右） 的数据进行合并成一个有序的序列
    ///     1、迁移 [begin, mid) 范围内的数据到新的数组中
    ///     2、对两个范围内的元素进行比较，并将较小者置于ai处
    ///         - 如果左边元素比较完毕，则结束合并
    ///         - 如果右边元素比较完毕，则将左边剩余元素全部插入到有序序列的尾部
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="mid"></param>
    /// <param name="end"></param>
    private void Merge(int begin, int mid, int end)
    {
        // 范围 [begin, mid) 数据的起始li索引，终止le索引
        var li = 0; // 因为需要将该范围内的数据迁移到新的数组上，所以默认都是从0开始
        var le = mid - begin;
        // 范围 [mid, end) 数据的起始ri索引，终止re索引
        var ri = mid;
        var re = end;
        // 比较后较大值插入的索引
        var ai = begin;
        
        // 迁移 [begin, mid) 数据
        for (int i = li; i < le; i++)
        {
            _leftArray[i] = array[i + begin];
        }

        // 如果左范围的序列元素比较完成，则结束合并
        while (li < le)
        {
            // 如果ri 小于 re (ri < re证明右边序列未必对完毕) 并且 右边元素小于左边元素
            if (ri < re && Cmp(array[ri], _leftArray[li]) < 0) // 如果比较条件改为 <= 则会导致不稳定
            {
                // 拷贝右边元素到array中，索引递增
                array[ai++] = array[ri++];
            }
            else
            {
                // 拷贝左边元素到array中，索引递增
                array[ai++] = _leftArray[li++];
            }
        }
    }
}