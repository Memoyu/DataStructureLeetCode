namespace 排序算法.冒泡排序;

public class SelectionSort<T> : BaseSort<T> where T : IComparable<T>
{
    protected override void Sort()
    {
        // 比较的结束点，每轮确定一次本轮的最大值，并将其放在最后
        for (int end = array.Length - 1; end > 0 ; end--)
        {
            // 本轮最大值的index
            var max = 0;
            for (int begin = 1; begin <= end; begin++)
            {
                if (Cmp(max, begin) < 0)
                    max = begin; // 如果已知的最大值比当前值小，则进行max变更为begin
            }
            
            // 本轮完成后，确定最大值，并与end的值进行交换
            Swap(max, end);
        }
    }
}