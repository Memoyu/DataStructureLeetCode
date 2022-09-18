namespace 图;

public abstract class Graph<TV, TW>
{
    protected IWeightManager<TW> WeightManager { get;}

    public Graph()
    {
        
    }
    
    public Graph(IWeightManager<TW> weightManager)
    {
        WeightManager = weightManager;
    }
    
    /// <summary>
    /// 获取图边数
    /// </summary>
    /// <returns></returns>
    public abstract int EdgesSize();

    /// <summary>
    /// 获取图节点数
    /// </summary>
    /// <returns></returns>
    public abstract int VerticesSize();

    /// <summary>
    /// 添加节点
    /// </summary>
    /// <param name="value">节点值</param>
    public abstract void AddVertex(TV value);

    /// <summary>
    /// 添加边
    /// </summary>
    /// <param name="from">起始节点</param>
    /// <param name="to">终止节点</param>
    public abstract void AddEdge(TV from, TV to);

    /// <summary>
    /// 添加边，带权值
    /// </summary>
    /// <param name="from">起始节点</param>
    /// <param name="to">终止节点</param>
    /// <param name="weight">权值</param>
    public abstract void AddEdge(TV from, TV to, TW weight);

    /// <summary>
    /// 移除节点
    /// </summary>
    /// <param name="value">节点值</param>
    public abstract void RemoveVertex(TV value);

    /// <summary>
    /// 移除边
    /// </summary>
    /// <param name="from">起始节点</param>
    /// <param name="to">终止节点</param>
    public abstract void RemoveEdge(TV from, TV to);

    /// <summary>
    /// 图遍历：广度优先搜索（Breadth First Search，BFS）
    /// </summary>
    /// <param name="value">起点位置，类似根节点</param>
    /// <param name="func">遍历操作，返回true则终止操作</param>
    public abstract void Bfs(TV value, Func<TV, bool> func);

    /// <summary>
    /// 图遍历：深度优先搜索（Depth First Search，DFS）
    /// </summary>
    /// <param name="value">起点位置，类似根节点</param>
    /// <param name="func">遍历操作，返回true则终止操作</param>
    public abstract void Dfs(TV value, Func<TV, bool> func);

    /// <summary>
    /// 拓扑排序
    /// </summary>
    /// <returns>排序后的Value</returns>
    public abstract List<TV> TopologicalSort();

    /// <summary>
    /// 获取最小生成树
    /// </summary>
    /// <param name="type">0：使用Prim；1：使用Kruskal;</param>
    /// <returns></returns>
    public abstract List<EdgeInfo<TV, TW>> Mst(int type);
    
    /// <summary>
    /// 单源最短路径
    /// </summary>
    /// <param name="begin">其实节点值</param>
    /// <param name="type">0：使用Dijkstra；1：使用BellmanFord;</param>
    /// <returns></returns>
    public abstract Dictionary<TV, PathInfo<TV, TW>> SingleSourceShortestPath(TV begin, int type);
    
    /// <summary>
    /// 多源最短路径
    /// 使用Floyd算法
    /// </summary>
    /// <returns>TV 能到达的所有节点的最短路径信息</returns>
    public abstract Dictionary<TV, Dictionary<TV, PathInfo<TV, TW>>> MultiSourceShortestPath();
}

/// <summary>
/// 最短路径信息
/// </summary>
public class PathInfo<TV, TW>
{
    /// <summary>
    /// 最短路径权值总和
    /// </summary>
    public TW Weight { get; set; }

    /// <summary>
    /// 最短路径边信息
    /// </summary>
    public LinkedList<EdgeInfo<TV, TW>> EdgeInfos { get; set; } = new();

    public PathInfo()
    {
        
    }

    public PathInfo(TW weight)
    {
        Weight = weight;
    }
    
    public override string ToString()
    {
        return $"PathInfo [ Weight={Weight}, PathInfos={string.Join(", ", EdgeInfos)} ]";
    }
}


/// <summary>
/// 对外部返回的边信息
/// </summary>
public class EdgeInfo<TV, TW>
{
    public TV To { get; set; }

    public TV From { get; set; }

    public TW Weight { get; set; }

    public EdgeInfo( TV from, TV to, TW weight)
    {
        From = from;
        To = to;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"EdgeInfo [ From={From}, To={To}, Weight={Weight} ]";
    }
}

public interface IWeightManager<TW>
{
    int Compare(TW w1, TW w2);
    TW Add(TW w1, TW w2);
    TW Zero();
}