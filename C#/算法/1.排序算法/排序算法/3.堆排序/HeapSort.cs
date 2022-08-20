namespace 排序算法._3.堆排序;

public class HeapSort<T> : BaseSort<T> where T : IComparable<T>
{
    protected override void Sort()
    {
        
    }

    /// <summary>
    /// 对堆进行下虑操作
    /// </summary>
    /// <param name="index"></param>
    private void SiftDown(int index)
    {
        var half = (array.Length >> 1);
        while (index < half)
        {
            
        }
    }
}