namespace 排序算法._7.希尔排序;

public class ShellSort<T> : BaseSort<T> where T : IComparable<T>
{
    protected override void Sort()
    {
        List<int> stepSequence = ShellStepSequence();
        foreach (var step in stepSequence)
        {
            Sort(step);
        }
    }

    /// <summary>
    /// 根据 step 列数对每一列进行快速排序
    /// </summary>
    /// <param name="step"></param>
    private void Sort(int step)
    {
        // 对第col列的元素进行插入排序
        for (int col = 0; col < step; col++) 
        {
            // 此处进行的是插入排序
            // 在矩阵中获取元素的索引公式为：col + row * step
            // 故，begin = col + step(因为插入查找从第二个元素开始)；下个元素为 begin + step
            for (int begin = col + step; begin < array.Length; begin += step)
            {
                int cur = begin;
                while (cur > col && Cmp(cur, cur - step) < 0)
                {
                    Swap(cur, cur - step);
                    cur -= step;
                }
            }
        }
    }

    /// <summary>
    /// 获取步长序列
    /// </summary>
    /// <returns></returns>
    private List<int> ShellStepSequence()
    {
        // 根据希尔给出的步长序列公式：n/2^k 进行步长序列获取
        // n 为数据规模，k 为自定参数，可任取，此处取1
        List<int> stepSequence = new List<int>();
        var step = array.Length;
        while ((step >>= 1) > 0)
        {
            stepSequence.Add(step);
        }

        return stepSequence;
    }
}