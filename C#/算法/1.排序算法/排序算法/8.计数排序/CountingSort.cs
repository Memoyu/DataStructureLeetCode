namespace 排序算法._8.计数排序;

public class CountingSort : BaseSort<int>
{
    protected override void Sort()
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
}