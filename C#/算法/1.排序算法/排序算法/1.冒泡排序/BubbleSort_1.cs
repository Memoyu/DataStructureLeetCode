namespace 排序算法._1.冒泡排序;

/// <summary>
/// 冒泡排序 优化1 如果经过一轮循环，发现已经是有序的，则直接终止
/// </summary>
/// <typeparam name="T"></typeparam>
public class BubbleSort_1<T> : BaseSort<T> where T : IComparable<T>
{
    protected override void Sort()
    {
        // 比较的结束点，每轮确定一次本轮的最大值，并将其放在最后
        for (int end = array.Length - 1 ; end > 0; end--)
        {
            // 标识序列是否为有序
            var sorted = true;
            // 进行本轮次比较，相邻的两个元素比较，较大的往后比较
            for (int begin = 1; begin <= end ; begin++)
            {
                // 如果 begin 比 begin - 1 小，则进行位置交换
                if (Cmp(begin, begin - 1) < 0)
                {
                    Swap(begin, begin - 1);
                    sorted = false; // 证明序列仍然为无序的
                }
            }

            // 本轮比较结束后，如果发现序列已经有序，则可以直接完成排序
            if (sorted) break;
        }
    }
}
