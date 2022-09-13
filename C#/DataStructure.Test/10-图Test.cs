using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;
using 图;
using 并查集;

namespace DataStructure.Test;

public class _10_图Test
{
    private int count = 1000000;
    private readonly ITestOutputHelper _output;
    private static readonly WeightManager<double> _doubleWeightManager = new DoubleWeightManager();

    public _10_图Test(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void GraphTest()
    {
        ListGraph<string, double> graph = new(_doubleWeightManager);
        graph.AddEdge("V1", "V0", 9);
        graph.AddEdge("V1", "V2", 3);
        graph.AddEdge("V2", "V0", 2);
        graph.AddEdge("V2", "V3", 5);
        graph.AddEdge("V3", "V4", 1);
        graph.AddEdge("V0", "V4", 6);

        // graph.RemoveEdge("V0", "V4");
        graph.RemoveVertex("V0");

        _output.WriteLine(graph.Print());
    }

    /// <summary>
    /// 广度优先搜索遍历Test
    /// </summary>
    [Fact]
    public void GraphBfsTest()
    {
        // Test 1
        _output.WriteLine("------------Test1------------");
        var graph = UnDirectedGraph(TestData.BFS_01);
        var result = new List<string>();
        graph.Bfs("A", v =>
        {
            result.Add(v.ToString());
            _output.WriteLine(v.ToString());
            return false;
        });
        Assert.Equal("A,B,F,C,I,G,E,D,H", string.Join(",", result));

        // Test 2
        _output.WriteLine("------------Test2------------");
        graph = DirectedGraph(TestData.BFS_02);
        result = new List<string>();
        graph.Bfs(0, v =>
        {
            result.Add(v.ToString());
            _output.WriteLine(v.ToString());
            return false;
        });
        Assert.Equal("0,1,4,2,6,7,5,3", string.Join(",", result));
    }

    /// <summary>
    /// 深度优先搜索遍历Test
    /// </summary>
    [Fact]
    public void GraphDfsTest()
    {
        // Test 1
        _output.WriteLine("------------Test1------------");
        var graph = UnDirectedGraph(TestData.DFS_01);
        var result = new List<string>();
        graph.Dfs(1, v =>
        {
            result.Add(v.ToString());
            _output.WriteLine(v.ToString());
            return false;
        });
        Assert.Equal("1,0,3,7,5,6,2,4", string.Join(",", result));

        // Test 2
        _output.WriteLine("------------Test2------------");
        graph = DirectedGraph(TestData.DFS_02);
        result = new List<string>();
        graph.Dfs("c", v =>
        {
            result.Add(v.ToString());
            _output.WriteLine(v.ToString());
            return false;
        });
        Assert.Equal("c,b,e,f", string.Join(",", result));
    }

    /// <summary>
    /// 拓扑排序Test
    /// </summary>
    [Fact]
    public void TopologicalSortTest()
    {
        var graph = DirectedGraph(TestData.TOPO);
        var result = graph.TopologicalSort();
        Assert.Equal("3,1,0,2,5,7,6,4", string.Join(",", result));
    }

    /// <summary>
    /// 有向图
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static Graph<object, double> DirectedGraph(object[][] data)
    {
        var graph = new ListGraph<object, double>(_doubleWeightManager);
        foreach (var edge in data)
        {
            if (edge.Length == 1)
            {
                graph.AddVertex(edge[0]);
            }
            else if (edge.Length == 2)
            {
                graph.AddEdge(edge[0], edge[1]);
            }
            else if (edge.Length == 3)
            {
                double weight = double.Parse(edge[2].ToString());
                graph.AddEdge(edge[0], edge[1], weight);
            }
        }

        return graph;
    }

    /// <summary>
    /// 无向图
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static Graph<object, double> UnDirectedGraph(object[][] data)
    {
        var graph = new ListGraph<object, double>(_doubleWeightManager);
        foreach (var edge in data)
        {
            if (edge.Length == 1)
            {
                graph.AddVertex(edge[0]);
            }
            else if (edge.Length == 2)
            {
                graph.AddEdge(edge[0], edge[1]);
                graph.AddEdge(edge[1], edge[0]);
            }
            else if (edge.Length == 3)
            {
                double weight = double.Parse(edge[2].ToString());
                graph.AddEdge(edge[0], edge[1], weight);
                graph.AddEdge(edge[1], edge[0], weight);
            }
        }

        return graph;
    }
}

public class DoubleWeightManager : WeightManager<double>
{
    public int Compare(double w1, double w2)
    {
        return w1.CompareTo(w2);
    }

    public double Add(double w1, double w2)
    {
        return w1 + w2;
    }

    public double Zero()
    {
        throw new NotImplementedException();
    }
}