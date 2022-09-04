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
} 
