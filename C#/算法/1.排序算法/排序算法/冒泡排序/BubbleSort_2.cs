namespace 排序算法.冒泡排序;

/// <summary>
/// 冒泡排序 优化2 记录最后一次的交换索引，并将其设置为下一轮比较的终点，减少最后有序位置的比较
/// </summary>
/// <typeparam name="T"></typeparam>
public class BubbleSort_2<T> : BaseSort<T> where T : IComparable<T>
{
    protected override void Sort()
    {
        // 比较的结束点，每轮确定一次本轮的最大值，并将其放在最后
        for (int end = Array.Length - 1 ; end > 0; end--)
        {
            // 用于记录最后一次进行交换的索引值
            var sortedIndex = 1;
            // 进行本轮次比较，相邻的两个元素比较，较大的往后比较
            for (int begin = 1; begin <= end ; begin++)
            {
                // 如果 begin 比 begin - 1 小，则进行位置交换
                if (Cmp(begin, begin - 1) < 0)
                {
                    Swap(begin, begin - 1);
                    sortedIndex = begin;
                }
            }

            // 本轮比较结束后，将最后一次进行交换的索引给到终结点
            end = sortedIndex;
        }
    }
}
