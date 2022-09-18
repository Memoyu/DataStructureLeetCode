using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using 图;
using 并查集;

namespace DataStructure.Test;

public class _10_图Test
{
    private int count = 1000000;
    private readonly ITestOutputHelper _output;
    private static readonly IWeightManager<double> _doubleWeightManager = new DoubleWeightManager();

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
    public void BfsTest()
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
    public void DfsTest()
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
    /// 最小生成树Test
    /// </summary>
    [Fact]
    public void MstByPrimTest()
    {
        _output.WriteLine("----------------MST-By-Prim-01--------------");
        var graph = UnDirectedGraph(TestData.MST_01);
        var result = graph.Mst(0);
        var actuals = new List<EdgeInfo<object, double>>
        {
            new(0, 2, 2),
            new(2, 1, 3),
            new(1, 5, 1),
            new(5, 6, 4),
            new(2, 4, 4),
            new(5, 7, 5),
            new(7, 3, 9),
        };

        foreach (var r in result)
        {
            _output.WriteLine(r.ToString());
            Assert.Contains(actuals, e => e.From.Equals(r.From) && e.To.Equals(r.To) && e.Weight == r.Weight);
        }

        _output.WriteLine("----------------MST-By-Prim-02--------------");

        graph = UnDirectedGraph(TestData.MST_02);
        result = graph.Mst(0);
        actuals = new List<EdgeInfo<object, double>>
        {
            new("A", "F", 1),
            new("F", "B", 11),
            new("B", "D", 5),
            new("D", "E", 4),
            new("B", "C", 6),
        };

        foreach (var r in result)
        {
            _output.WriteLine(r.ToString());
            Assert.Contains(actuals, e => e.From.Equals(r.From) && e.To.Equals(r.To) && e.Weight == r.Weight);
        }
    }

    [Fact]
    public void MstByKruskalTest()
    {
        _output.WriteLine("----------------MST-By-Kruskal-01--------------");
        var graph = UnDirectedGraph(TestData.MST_01);
        var result = graph.Mst(1);
        var actuals = new List<EdgeInfo<object, double>>
        {
            new(1, 5, 1),
            new(2, 0, 2),
            new(2, 1, 3),
            new(5, 6, 4),
            new(2, 4, 4),
            new(7, 5, 5),
            new(3, 7, 9),
        };

        foreach (var r in result)
        {
            _output.WriteLine(r.ToString());
            Assert.Contains(actuals, e =>  e.From.Equals(r.From) && e.To.Equals(r.To) && e.Weight == r.Weight);
        }

        _output.WriteLine("----------------MST-By-Kruskal-02--------------");

        graph = UnDirectedGraph(TestData.MST_02);
        result = graph.Mst(1);
        actuals = new List<EdgeInfo<object, double>>
        {
            new("A", "F", 1),
            new("D", "E", 4),
            new("B", "D", 5),
            new("B", "C", 6),
            new("B", "F", 11),
        };

        foreach (var r in result)
        {
            _output.WriteLine(r.ToString());
            Assert.Contains(actuals, e =>  e.From.Equals(r.From) && e.To.Equals(r.To) && e.Weight == r.Weight);
        }
    }

    /// <summary>
    /// 单源最短路径Test
    /// </summary>
    [Fact]
    public void SingleSourceShortestByDijkstraTest()
    {
        var graph = UnDirectedGraph(TestData.SP);
        var result = graph.SingleSourceShortestPath("A",0);
        foreach (var r in result)
        {
            _output.WriteLine($"{r.Key} - {r.Value}");
        }
    }
    
    [Fact]
    public void SingleSourceShortestByBellmanFordTest()
    {
        var graph = DirectedGraph(TestData.NEGATIVE_WEIGHT1);
        var result = graph.SingleSourceShortestPath("A",1);
        foreach (var r in result)
        {
            _output.WriteLine($"{r.Key} - {r.Value}");
        }
    }
    
    /// <summary>
    /// 多源最短路径Test
    /// </summary>
    [Fact]
    public void MultiSourceShortestByBellmanFordTest()
    {
        var graph = DirectedGraph(TestData.SP);
        var result = graph.MultiSourceShortestPath();
        foreach (var f in result)
        {
            _output.WriteLine(f.Key + " ---------------------");
            foreach (var t in f.Value)
            {
                _output.WriteLine(t.Key + " - " + t.Value);
            }
        }
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

public class DoubleWeightManager : IWeightManager<double>
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
        return 0d;
    }
}