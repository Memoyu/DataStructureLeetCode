namespace 排序算法.冒泡排序;

/// <summary>
/// 冒泡排序 基本实现
/// </summary>
/// <typeparam name="T"></typeparam>
public class BubbleSort<T> : BaseSort<T> where T : IComparable<T>
{
    protected override void Sort()
    {
        // 比较的结束点，每轮确定一次本轮的最大值，并将其放在最后
        for (int end = array.Length - 1 ; end > 0; end--)
        {
            // 进行本轮次比较，相邻的两个元素比较，较大的往后比较
            for (int begin = 1; begin <= end ; begin++)
            {
                // 如果 begin 比 begin - 1 小，则进行位置交换
                if (Cmp(begin, begin - 1 ) < 0)
                    Swap(begin, begin - 1);
            }
        }
    }
}
