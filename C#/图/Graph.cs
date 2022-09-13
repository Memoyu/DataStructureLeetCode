namespace 图;

public abstract class Graph<TV, TW>
{
    public WeightManager<TW> WeightManager { get; set; }

    public Graph()
    {
        
    }
    
    public Graph(WeightManager<TW> weightManager)
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
    /// 对外部返回的边信息
    /// </summary>
    public class EdgeInfo
    {
        public TV To { get; set; }

        public TV From { get; set; }

        public TW Weight { get; set; }

        public EdgeInfo(TV to, TV from, TW weight)
        {
            To = to;
            From = from;
            Weight = weight;
        }
    }
}

public interface WeightManager<TW>
{
    int Compare(TW w1, TW w2);
    TW Add(TW w1, TW w2);
    TW Zero();
}