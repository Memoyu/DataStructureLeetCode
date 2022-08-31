namespace 排序算法._9.基数排序;

public class RadixSort : BaseSort<int>
{
    protected override void Sort()
    {
        // 获取序列最大值
        var max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max) max = array[i];
        }

        // 用于存放当前基数排序后的结果集
        int[] output = new int[array.Length];
        // 用于存放出现次数，对应的基数只有0-9，故长度为常亮10
        int[] counts = new int[10];
        // 对最大值进行基数分解，每个基数进行一轮计数排序
        // 个位数：567 / 1   % 10 = 7
        // 十位数：567 / 10  % 10 = 6
        // 百位数：567 / 100 % 10 = 5
        for (int divider = 1; divider < max; divider *= 10)
        {
            CountingSort(divider, output, counts);
        }
    }

    /// <summary>
    /// 使用计数排序对当前基数进行排序
    /// </summary>
    /// <param name="divi der">基数</param>
    /// <param name="output">基数排序结果集</param>
    /// <param name="counts">计数结果集</param>
    private void CountingSort(int divider, int[] output, int[] counts)
    {
        // 清空计数结果集（为了不多次创建，所以从外部传入）
        for (int i = 0; i < counts.Length; i++)
        {
            counts[i] = 0;
        }

        // 进行当前基数的次数进行统计，值得的范围 [0,10)
        for (int i = 0; i < array.Length; i++)
        {
            counts[array[i] / divider % 10]++;
        }

        // 进行计数累加
        for (int i = 1; i < counts.Length; i++)
        {
            counts[i] += counts[i - 1];
        }

        // 进行排序
        for (int i = array.Length; i >= 0; i--)
        {
            // 获取排序后的下标，对计数进行递减，并将值添加到有序数组中
            var index = counts[array[i] / divider % 10] -= 1;
            output[index] = array[i];
        }

        // 将本轮排序覆写回原序列
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = output[i];
        }
    }
}