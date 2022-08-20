using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;
using 排序算法;
using 排序算法._1.冒泡排序;
using 排序算法._2.选择排序;

namespace DataStructrue.Test;

public class _5_排序算法Test
{
    private readonly ITestOutputHelper _output;

    private readonly int[] _array;

    public _5_排序算法Test(ITestOutputHelper output)
    {
        _output = output;

        var range = 100000;
        var cnt = 10000;
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
            // new BubbleSort<int>(),
            // new BubbleSort_1<int>(),
            new BubbleSort_2<int>(),
            new SelectionSort<int>()
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