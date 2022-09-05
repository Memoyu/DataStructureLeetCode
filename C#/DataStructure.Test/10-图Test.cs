using System;
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

    public _10_图Test(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void GraphTest()
    {
        ListGraph<string, int> graph = new ();
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
}