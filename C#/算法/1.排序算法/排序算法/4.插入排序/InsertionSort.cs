namespace 排序算法._4.插入排序;

public class InsertionSort<T> : BaseSort<T> where T : IComparable<T>
{
    protected override void Sort()
    {
        // 共识：升序排序为例
        // 原理：将序列分成两个区域，一个是有序区，一个是待排序区；
        //  - 在待排序区中将元素取出，并与有序区元素进行逐个比对；
        //  - 较有序区元素小时，则进行位置交换，否则结束本次
        //  - 重复如上步骤

        // 最原始的方式：交换元素
        // Sort_1();
        // 最原始的方式：挪动元素
        Sort_2();
        
        
    }

    private void Sort_1()
    {
        // 外层循环，用于遍历待排序区元素
        for (int begin = 1; begin < array.Length; begin++)
        {
            // 内层循环，用于将待排序区元素与有序区元素进行比对，符合条件则交换位置
            var curr = begin;
            while (curr > 0 && Cmp(curr, curr - 1) < 0)
            {
                Swap(curr, curr - 1);
                curr--;
            }
        }
    }

    private void Sort_2()
    {
        // 外层循环，用于遍历待排序区元素
        for (int begin = 1; begin < array.Length; begin++)
        {
            // 内层循环，用于将待排序区元素与有序区元素进行比对，符合条件则把当前元素往后挪动（优化点就在这，将原本的【交换】换成【挪动】，进而减少操作）
            var curr = begin;
            // 获取当前待排序的元素
            var value = array[curr];
            while (curr > 0 && Cmp(value, array[curr - 1]) < 0)
            {
                // 将当前元素往后挪动，以便于确定位置后将value插入
                array[curr] = array[curr - 1];
                curr--;
            }

            array[curr] = value;
        }
    }
}