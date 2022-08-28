using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using 排序算法._1.冒泡排序;
using 排序算法._7.希尔排序;
using 排序算法._8.计数排序;

namespace 排序算法;

public abstract class BaseSort<T> : IComparable<BaseSort<T>>
    where T : IComparable<T>
{
    // 排序数组
    protected T[] array { get; set; }

    // 比对计数器
    private int _cmpCnt;

    // 交换计数器
    private int _swapCnt;

    // 排序耗时
    private long _time;

    /// <summary>
    /// 外部调用排序
    /// </summary>
    /// <param name="array"></param>
    public void Sort(T[] array)
    {
        Console.WriteLine(GetType().Name);
        if (array == null || array.Count() < 2) return;
        this.array = array;
        var sw = new Stopwatch();
        sw.Start();
        Sort();
        sw.Stop();
        _time = sw.ElapsedMilliseconds;
    }

    /// <summary>
    /// 排序抽象
    /// </summary>
    protected abstract void Sort();

    /// <summary>
    /// Sort 实例比对排序
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(BaseSort<T> other)
    {
        // 耗时比对
        var cmp = (int)(_time - other._time);
        if (cmp != 0) return cmp; // 不相等则直接返回比对结果

        // 比对次数
        cmp = _cmpCnt - other._cmpCnt;
        if (cmp != 0) return cmp; // 不相等则直接返回比对结果

        // 交换次数
        return _swapCnt - other._swapCnt;
    }

    /// <summary>
    /// 传入索引，比对值
    /// 返回等于0 则 Array[ind1] == Array[ind2]
    /// 返回小于0 则 Array[ind1] < Array[ind2]
    /// 返回大雨0 则 Array[ind1] > Array[ind2]
    /// </summary>
    /// <param name="ind1"></param>
    /// <param name="ind2"></param>
    /// <returns></returns>
    protected int Cmp(int ind1, int ind2)
    {
        _cmpCnt++;
        return array[ind1].CompareTo(array[ind2]);
    }

    /// <summary>
    /// 传入值，比对值
    /// </summary>
    /// <param name="val1"></param>
    /// <param name="val2"></param>
    /// <returns></returns>
    protected int Cmp(T val1, T val2)
    {
        _cmpCnt++;
        return val1.CompareTo(val2);
    }

    /// <summary>
    /// 交换值
    /// </summary>
    /// <param name="ind1"></param>
    /// <param name="ind2"></param>
    protected void Swap(int ind1, int ind2)
    {
        _swapCnt++;
        (array[ind1], array[ind2]) = (array[ind2], array[ind1]);
    }

    public override string ToString()
    {
        var timeStr = "耗时：" + (_time / 1000.0) + "s(" + _time + "ms)";
        var compareCountStr = "比较：" + NumberString(_cmpCnt);
        var swapCountStr = "交换：" + NumberString(_swapCnt);
        var stableStr = "稳定性：" + IsStable();
        return "【" + GetType().Name + "】\n"
               + stableStr + " \t"
               + timeStr + " \t"
               + compareCountStr + "\t "
               + swapCountStr + "\n"
               + "------------------------------------------------------------------";
    }

    /// <summary>
    /// 将数值转成万、亿单位
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private string NumberString(int number)
    {
        if (number < 10000) return "" + number;
        if (number < 100000000) return $"{number / 10000.0}万";
        return $"{number / 100000000.0}亿";
    }

    public bool IsStable()
    {
        if (GetType() == typeof(CountingSort)) return false;
        if (GetType() == typeof(ShellSort<int>)) return false;
        var students = new Student[20];
        for (int i = 0; i < students.Count(); i++)
        {
            students[i] = new Student(i * 10, 10);
        }

        var type = GetType().GetGenericTypeDefinition().MakeGenericType(typeof(Student)); //根据类型参数获取具象泛型
        var sort = (BaseSort<Student>)Activator.CreateInstance(type);
        sort.Sort(students);
        for (int i = 1; i < students.Length; i++)
        {
            int score = students[i].Score;
            int prevScore = students[i - 1].Score;
            if (score != prevScore + 10) return false;
        }

        return true;
    }
}

public class Student : IComparable<Student>
{
    public int Score { get; set; }
    public int Age { get; set; }

    public Student(int score, int age)
    {
        Score = score;
        Age = age;
    }


    public int CompareTo(Student? other)
    {
        return Age - other.Age;
    }
}