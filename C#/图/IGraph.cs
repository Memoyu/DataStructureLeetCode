namespace 图;

public interface IGraph<TV, TW>
{
    /// <summary>
    /// 获取图边数
    /// </summary>
    /// <returns></returns>
    int EdgesSize();
    
    /// <summary>
    /// 获取图节点数
    /// </summary>
    /// <returns></returns>
    int VerticesSize();
    
    /// <summary>
    /// 添加节点
    /// </summary>
    /// <param name="value">节点值</param>
    void AddVertex(TV value);

    /// <summary>
    /// 添加边
    /// </summary>
    /// <param name="from">起始节点</param>
    /// <param name="to">终止节点</param>
    void AddEdge(TV from, TV to);
    
    /// <summary>
    /// 添加边，带权值
    /// </summary>
    /// <param name="from">起始节点</param>
    /// <param name="to">终止节点</param>
    /// <param name="weight">权值</param>
    void AddEdge(TV from, TV to, TW weight);

    /// <summary>
    /// 移除节点
    /// </summary>
    /// <param name="value">节点值</param>
    void RemoveVertex(TV value);
    
    /// <summary>
    /// 移除边
    /// </summary>
    /// <param name="from">起始节点</param>
    /// <param name="to">终止节点</param>
    void RemoveEdge(TV from, TV to);

    /// <summary>
    /// 图遍历：广度优先搜索（Breadth First Search，BFS）
    /// </summary>
    /// <param name="value">起点位置，类似根节点</param>
    /// <param name="func">遍历操作，返回true则终止操作</param>
    void Bfs(TV value, Func<TV, bool> func);
    
    /// <summary>
    /// 图遍历：深度优先搜索（Depth First Search，DFS）
    /// </summary>
    /// <param name="value">起点位置，类似根节点</param>
    /// <param name="func">遍历操作，返回true则终止操作</param>
    void Dfs(TV value, Func<TV, bool> func);
} 
