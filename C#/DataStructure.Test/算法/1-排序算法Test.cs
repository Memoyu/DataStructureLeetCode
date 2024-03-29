using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using 排序算法;
using 排序算法._1.冒泡排序;
using 排序算法._2.选择排序;
using 排序算法._3.堆排序;
using 排序算法._4.插入排序;
using 排序算法._5.归并排序;
using 排序算法._6.快速排序;
using 排序算法._7.希尔排序;
using 排序算法._8.计数排序;

namespace DataStructure.Test.算法;

public class _1_排序算法Test
{
    private readonly ITestOutputHelper _output;

    private readonly int[] _array;

    public _1_排序算法Test(ITestOutputHelper output)
    {
        _output = output;

        var range = 30000;
        var cnt = 200;
        // var range = 100;
        // var cnt = 10;
        _array = new int[cnt];
        Random r = new Random();
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = r.Next(1, range);
        }

        //  _output.WriteLine(JsonSerializer.Serialize(_array));
    }

    [Fact]
    public void SortTest()
    {
        var sorters = new List<BaseSort<int>>
        {
            new BubbleSort<int>(),
            new SelectionSort<int>(),
            new HeapSort<int>(),
            new InsertionSort<int>(),
            new MergeSort<int>(),
            new QuickSort<int>(),
            new ShellSort<int>(),
            new CountingSort()
        };

        foreach (var sorter in sorters)
        {
            var arr = _array.ToArray();
            sorter.Sort(arr);
            Assert.True(IsAscOrder(arr));
        }

        sorters.Sort();

        foreach (var sorter in sorters)
        {
            _output.WriteLine(sorter.ToString());
        }
    }

    private bool IsAscOrder<T>(T[] arr) where T : IComparable
    {
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i].CompareTo(arr[i - 1]) < 0)
            {
                return false;
            }
        }

        return true;
    }
}