using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;
using 并查集;

namespace DataStructure.Test;

public class _9_并查集Test
{
    private int count = 1000000;
    private readonly ITestOutputHelper _output;

    public _9_并查集Test(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void UnionFindTest()
    {
        TestTime(new UnionFind_QF(count));
        TestTime(new UnionFind_QU(count));
        TestTime(new UnionFind_QU_S(count));
        TestTime(new UnionFind_QU_R(count));
        TestTime(new UnionFind_QU_R_PC(count));
        TestTime(new UnionFind_QU_R_PS(count));
        TestTime(new UnionFind_QU_R_PH(count));
        TestTime(new GenericUnionFind<int>());
    }

    void TestTime(GenericUnionFind<int> uf)
    {
        for (int i = 0; i < count; i++)
        {
            uf.MakeSet(i);
        }

        uf.Union(0, 1);
        uf.Union(0, 3);
        uf.Union(0, 4);
        uf.Union(2, 3);
        uf.Union(2, 5);

        uf.Union(6, 7);

        uf.Union(8, 10);
        uf.Union(9, 10);
        uf.Union(9, 11);

        Assert.True(!uf.IsSame(2, 7));

        uf.Union(4, 6);

        Assert.True(uf.IsSame(2, 7));

        TestOutput(uf.GetType().ToString(), () =>
        {
            for (int i = 0; i < count; i++)
            {
                uf.Union((int)(new Random().Next(0, 1) * count),
                    (int)(new Random().Next(0, 1) * count));
            }

            for (int i = 0; i < count; i++)
            {
                uf.IsSame((int)(new Random().Next(0, 1) * count),
                    (int)(new Random().Next(0, 1) * count));
            }
        });
    }

    private void TestTime(UnionFind uf)
    {
        uf.Union(0, 1);
        uf.Union(0, 3);
        uf.Union(0, 4);
        uf.Union(2, 3);
        uf.Union(2, 5);

        uf.Union(6, 7);

        uf.Union(8, 10);
        uf.Union(9, 10);
        uf.Union(9, 11);

        Assert.True(!uf.IsSame(2, 7));

        uf.Union(4, 6);

        Assert.True(uf.IsSame(2, 7));

        TestOutput(uf.GetType().ToString(), () =>
        {
            for (int i = 0; i < count; i++)
            {
                uf.Union((int)(new Random().Next(0, 1) * count),
                    (int)(new Random().Next(0, 1) * count));
            }

            for (int i = 0; i < count; i++)
            {
                uf.IsSame((int)(new Random().Next(0, 1) * count),
                    (int)(new Random().Next(0, 1) * count));
            }
        });
    }

    private void TestOutput(string? title, Action? action)
    {
        if (action == null) return;
        title = (title == null) ? "" : ("【" + title + "】");
        _output.WriteLine(title);
        var sw = new Stopwatch();
        sw.Start();
        action.Invoke();
        sw.Stop();
        _output.WriteLine("耗时：" + sw.ElapsedMilliseconds / 1000d + "毫秒");
        _output.WriteLine("-------------------------------------");
    }
}