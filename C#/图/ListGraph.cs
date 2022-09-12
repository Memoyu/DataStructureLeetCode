using System.Text;

namespace 图;

public class ListGraph<TV, TW> : IGraph<TV, TW>
{
    private Dictionary<TV, Vertex<TV, TW>> _vertices = new();
    private HashSet<Edge<TV, TW>> _edges = new();

    public int EdgesSize()
    {
        return _edges.Count;
    }

    public int VerticesSize()
    {
        return _vertices.Count;
    }

    public void AddVertex(TV value)
    {
        if (_vertices.ContainsKey(value)) return;
        _vertices.Add(value, new Vertex<TV, TW>(value));
    }

    public void AddEdge(TV from, TV to)
    {
        AddEdge(from, to, default);
    }

    public void AddEdge(TV from, TV to, TW weight)
    {
        // from、to 是否存在，不存在则进行新增节点
        var fromExist = _vertices.TryGetValue(from, out var fromVertex);
        if (!fromExist)
        {
            fromVertex = new Vertex<TV, TW>(from);
            _vertices.Add(from, fromVertex);
        }

        var toExist = _vertices.TryGetValue(to, out var toVertex);
        if (!toExist)
        {
            toVertex = new Vertex<TV, TW>(to);
            _vertices.Add(to, toVertex);
        }

        // 构建新的边
        var edge = new Edge<TV, TW>(fromVertex, toVertex);
        edge.Weight = weight;

        // 此处为了节省操作，直接删除，有的话就删除出度成功，并且删除入度，否则不操作
        if (fromVertex.OutEdges.Remove(edge))
        {
            toVertex.InEdges.Remove(edge);
            // 移除全局edge
            _edges.Remove(edge);
        }

        // 添加新的edge
        fromVertex.OutEdges.Add(edge);
        toVertex.InEdges.Add(edge);
        _edges.Add(edge);
    }

    public void RemoveVertex(TV value)
    {
        // 尝试移除节点
        var remove = _vertices.Remove(value, out var vertex);
        if (!remove) return; // 移除成功并继续操作
        var iterableOut = vertex.OutEdges.GetEnumerator();
        while (iterableOut.MoveNext())
        {
            var egde = iterableOut.Current;
            egde.To.InEdges.Remove(egde);
            vertex.OutEdges.Remove(egde);
            _edges.Remove(egde);
        }

        var iterableIn = vertex.InEdges.GetEnumerator();
        while (iterableIn.MoveNext())
        {
            var egde = iterableIn.Current;
            egde.From.OutEdges.Remove(egde);
            vertex.InEdges.Remove(egde);
            _edges.Remove(egde);
        }
    }

    public void RemoveEdge(TV from, TV to)
    {
        // 节点不存在则结束
        var fromExist = _vertices.TryGetValue(from, out var fromVertex);
        if (!fromExist) return;
        var toExist = _vertices.TryGetValue(to, out var toVertex);
        if (!toExist) return;

        // 删除边
        var edge = new Edge<TV, TW>(fromVertex, toVertex);
        if (fromVertex.OutEdges.Remove(edge))
        {
            toVertex.InEdges.Remove(edge);
            // 移除全局edge
            _edges.Remove(edge);
        }
    }

    public void Bfs(TV value, Func<TV, bool> func)
    {
        if (func == null) return;
        // 类似于二叉树层序遍历，故可使用队列进行实现
        var queue = new Queue<Vertex<TV, TW>>();

        // 需要引入HashSet存储遍历过的节点，并在遍历过程中排除这些节点
        var visitedVertices = new HashSet<Vertex<TV, TW>>();
        var beginVertex = _vertices[value];
        queue.Enqueue(beginVertex);
        visitedVertices.Add(beginVertex);

        // 队列不为空则继续进行遍历操作
        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            // 外部控制是否需要终止操作
            if (func(vertex.Value)) return;

            // 遍历节点的所有边
            foreach (var edge in vertex.OutEdges)
            {
                // 校验该边的终节点是否已经遍历过，是则终止本次操作，否则继续
                if (visitedVertices.Contains(edge.To)) continue;
                queue.Enqueue(edge.To);
                visitedVertices.Add(edge.To);
            }
        }
    }

    public void Dfs(TV value, Func<TV, bool> func)
    {
        if (func == null) return;
        var beginVertex = _vertices[value];
        // 类似于二叉树的前序遍历，故可使用如下两种方式实现
        // 递归版本
        var visitedVertices = new HashSet<Vertex<TV, TW>>();
        // DfsRecursive(beginVertex,visitedVertices, func);
        // 非递归版本
        DfsNonRecursive(beginVertex, visitedVertices, func);
    }

    /// <summary>
    /// 递归实现 深度优先搜索
    /// </summary>
    /// <param name="vertex"></param>
    /// <param name="visitedVertices"></param>
    /// <param name="func"></param>
    private void DfsRecursive(Vertex<TV, TW> vertex, HashSet<Vertex<TV, TW>> visitedVertices, Func<TV, bool> func)
    {
        if (vertex == null) return;
        if (func(vertex.Value)) return;
        visitedVertices.Add(vertex);
        foreach (var edge in vertex.OutEdges)
        {
            if (visitedVertices.Contains(edge.To)) continue;
            DfsRecursive(edge.To, visitedVertices, func);
        }
    }

    /// <summary>
    /// 非递归实现 深度优先搜索
    /// </summary>
    /// <param name="vertex"></param>
    /// <param name="visitedVertices"></param>
    /// <param name="func"></param>
    private void DfsNonRecursive(Vertex<TV, TW> vertex, HashSet<Vertex<TV, TW>> visitedVertices, Func<TV, bool> func)
    {
        var stack = new Stack<Vertex<TV, TW>>();

        // 访问起点
        stack.Push(vertex);
        if (func(vertex.Value)) return;
        visitedVertices.Add(vertex);

        // 读栈中节点，
        while (stack.Count > 0)
        {
            // 弹出栈顶节点
            vertex = stack.Pop();
            
            // 遍历节点的出度边，此处一次只会遍历其中一条边
            foreach (var edge in vertex.OutEdges)
            {
                // 如果节点的To已经被访问过，则结束
                if (visitedVertices.Contains(edge.To)) continue;
                
                // 将节点的From、To添加到栈中、添加到已访问记录中，以及执行操作
                stack.Push(edge.From);
                stack.Push(edge.To);
                visitedVertices.Add(edge.To);
                if (func(edge.To.Value)) return;
                // 终止本次遍历
                break;
            }
        }
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[顶点]-------------------\n");
        foreach (var v in _vertices)
        {
            sb.Append($"{v.Key}\n");
            sb.Append("out-----------\n");
            sb.Append($"{string.Join("\n", v.Value.OutEdges)}\n");
            sb.Append("in-----------\n");
            sb.Append($"{string.Join("\n", v.Value.InEdges)}\n");
        }

        sb.Append("[边]-------------------\n");
        foreach (var e in _edges)
        {
            sb.Append($"{e}\n");
        }

        return sb.ToString();
    }
}

/// <summary>
/// 顶点信息
/// </summary>
/// <typeparam name="TV">顶点类型</typeparam>
/// <typeparam name="TW">顶点类型</typeparam>
internal class Vertex<TV, TW>
{
    public Vertex(TV value)
    {
        Value = value;
    }

    public TV Value { get; set; }

    /// <summary>
    /// 入度，作为终点的边集合
    /// </summary>
    public HashSet<Edge<TV, TW>> InEdges { get; set; } = new();

    /// <summary>
    /// 出度，作为起点的边集合
    /// </summary>
    public HashSet<Edge<TV, TW>> OutEdges { get; set; } = new();

    public override bool Equals(object obj)
    {
        var vertex = (Vertex<TV, TW>)obj;
        return Equals(Value, vertex.Value);
    }

    public override int GetHashCode()
    {
        return Value is null ? 0 : Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value == null ? "null" : Value.ToString();
    }
}

/// <summary>
/// 边信息
/// </summary>
/// <typeparam name="TV">顶点类型</typeparam>
/// <typeparam name="TW">权值类型</typeparam>
internal class Edge<TV, TW>
{
    public Edge(Vertex<TV, TW> from, Vertex<TV, TW> to)
    {
        From = from;
        To = to;
    }

    /// <summary>
    /// 起点顶点
    /// </summary>
    public Vertex<TV, TW> From { get; set; }

    /// <summary>
    /// 终点顶点
    /// </summary>
    public Vertex<TV, TW> To { get; set; }

    /// <summary>
    /// 权值
    /// </summary>
    public TW Weight { get; set; }

    public override bool Equals(object obj)
    {
        var edge = (Edge<TV, TW>)obj;
        return Equals(From, edge.From) && Equals(To, edge.To);
    }

    public override int GetHashCode()
    {
        int fromCode = From.GetHashCode();
        int toCode = To.GetHashCode();
        return fromCode * 31 + toCode;
    }

    public override string ToString()
    {
        return "Edge [from=" + From + ", to=" + To + ", weight=" + Weight + "]";
    }
}