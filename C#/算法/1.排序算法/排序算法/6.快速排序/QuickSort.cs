namespace 排序算法._6.快速排序;

public class QuickSort<T> : BaseSort<T> where T : IComparable<T>
{
    protected override void Sort()
    {
        Sort(0, array.Length);
    }

    /// <summary>
    /// 对指定范围 [begin, end) 元素进行快速排序 
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    private void Sort(int begin, int end)
    {
        // 小于2个元素则说明不再需要排序
        if (end - begin < 2) return;
        var pivot = PivotIndex(begin, end);
        // 对子序列进行快速排序
        Sort(begin, pivot);
        Sort(pivot + 1, end);
    }

    /// <summary>
    /// 构造范围 [begin, end) 的轴点元素索引
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private int PivotIndex(int begin, int end)
    {
        // 重点：
        //  1. 随机获取轴点元素是为了降低最坏情况出现的概率；
        //  2. 巧妙利用while实现特定条件调转方向，而调转方向是为了更方便的实现元素覆盖；
        //  3. 与轴点比较时没有使用 <= 或 >= 是为了减少最坏情况的出现；

        // 随机获取轴点元素
        Swap(begin, begin + ((new Random().Next(0, 1)) * (end - begin)));

        // 默认取第一个元素作为轴点元素
        var value = array[begin];
        // 源于 [begin, end) 是左闭右开，所以end索引应该往前一位
        end--;

        // 当begin = end 的时候，证明轴点构造完成
        while (begin < end)
        {
            // 方向1：从 end -> begin 扫描
            while (begin < end)
            {
                // 当end索引的值大于轴点的值时，则无需操作覆盖，进行位移即可，否则进行元素覆盖到begin位置
                if (Cmp(value, array[end]) < 0)
                {
                    // 索引往前移
                    end--;
                }
                else
                {
                    // 进行了覆盖后，则需要调转方向，即退出循环
                    array[begin++] = array[end];
                    break;
                }
            }

            // 方向2：从 begin -> end 扫描
            while (begin < end)
            {
                // 当begin索引的值大于轴点的值时，则无需操作覆盖，进行位移即可，否则进行元素覆盖到end位置
                if (Cmp(value, array[begin]) > 0)
                {
                    // 索引往后移
                    begin++;
                }
                else
                {
                    // 进行了覆盖后，则需要调转方向，即退出循环
                    array[end--] = array[begin];
                    break;
                }
            }
        }

        // 将轴点元素放到最终位置
        array[begin] = value;
        // 将轴点元素索引返回
        return begin;
    }
}