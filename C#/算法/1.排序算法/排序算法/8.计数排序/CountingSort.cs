namespace 排序算法._8.计数排序;

public class CountingSort : BaseSort<int>
{
    protected override void Sort()
    {
       // 基础版本
       // Sort_0();
       // 优化后版本
       Sort_1();
    }
    
    /// <summary>
    /// 基础版本
    /// - 无法对负整数进行排序；
    /// - 极其浪费内存空间；
    /// - 是个不稳定的排序；
    /// </summary>
    private void Sort_0()
    {
        // 获取序列最大值
        var max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max) max = array[i];
        }
        
        // 构造序列值对应出现次数数组
        var counts = new int[max + 1];
        foreach (var t in array)
        {
            // 取出值对应值并进行自增1
            counts[t]++;
        }
        
        // 按counts数组顺序覆盖array，形成有序数组
        var cur = 0;
        for (int i = 0; i < counts.Length; i++)
        {
            // 当值的次数大于0时持续覆盖
            while (counts[i] > 0)
            {
                array[cur] = i;
                cur++; // array覆盖索引往后移
                counts[i]--; // counts值对应的次数 -1
            }
        }
    }

    /// <summary>
    /// 优化排序，优化基础版本存在问题
    /// </summary>
    private void Sort_1()
    {
        // 获取序列最大值、最小值
        var max = array[0];
        var min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max) max = array[i];
            if (array[i] < min) min = array[i];
        }
        
        // 构造序列值对应出现次数数组
        var counts = new int[(max - min) + 1];
        // 值对应次数
        for (int i = 0; i < array.Length; i++)
        {
            // 取出值对应值并进行自增1
            counts[array[i] - min]++;
        }
        // 累加次数
        for (int i = 1; i < counts.Length; i++)
        {
            counts[i] += counts[i - 1];
        }
        
        // 构建有序序列
        var news = new int[array.Length];
        for (int i = array.Length - 1; i >= 0; i--)
        {
            // 获取值在有序序列中的索引
            var index = counts[array[i] - min] -= 1;
            news[index] = array[i];
        }
        // 覆盖array
        for (int i = 0; i < news.Length; i++)
        {
            array[i] = news[i];
        }
    }
}