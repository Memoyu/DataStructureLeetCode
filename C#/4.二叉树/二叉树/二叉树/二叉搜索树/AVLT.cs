using 二叉树.二叉树.Base;

namespace 二叉树.二叉树.二叉搜索树;

/// <summary>
/// AVL 树
/// </summary>
public class AVLT<T> : BST<T>
{
    public AVLT()
    {
    }

    public AVLT(IComparer<T> comparer) : base(comparer)
    {
    }

    protected override TreeNode<T> CreateNode(T value, TreeNode<T> parentNode)
    {
        return new AVLNode<T>(value, parentNode);
    }

    protected override void AfterAdd(TreeNode<T> node)
    {
        while ((node = node.Parent) != null)
        {
            if (IsBalanced(node))
            { // 平衡的，进行高度更新
                UpdateHeight(node);
            }
            else
            { // 不平衡的，进行恢复平衡
                ReBalance(node);
                // 只要找到第一个不平衡的，将其恢复平衡，整棵树即可获得平衡，所以可结束
                break;
            }
        }

    }

    /// <summary>
    /// 是否平衡
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private bool IsBalanced(TreeNode<T> node)
    {
        // 每个节点的平衡因子只可能是1、0、-1，所以只要绝对值大于1，都是不平衡的
        return Math.Abs(((AVLNode<T>)node).BalanceFactor()) <= 1;
    }

    /// <summary>
    /// 更新节点高度
    /// </summary>
    /// <param name="node"></param>
    private void UpdateHeight(TreeNode<T> node)
    {
        ((AVLNode<T>)node).UpdateHeight();
    }

    /// <summary>
    /// 进行平衡恢复
    /// </summary>
    /// <param name="node">node必然是第一个发现不平衡的节点，故为高度最低的不平衡节点（因为是从创建节点一直往上找，一直往父节点找）</param>
    private void ReBalance(TreeNode<T> node)
    {
    }
}

public class AVLNode<T> : TreeNode<T>
{
    // 默认等于1，因为每个节点添加进来都是叶子节点，而叶子节点的高度都是1，后期再进行更细
    public int Height { get; set; } = 1;

    public AVLNode(T value, TreeNode<T> parent) : base(value, parent)
    {
    }

    /// <summary>
    /// 平衡因子
    /// </summary>
    /// <returns></returns>
    public int BalanceFactor()
    {
        int leftHeight = Left == null ? 0 : ((AVLNode<T>)Left).Height;
        int rightHeight = Right == null ? 0 : ((AVLNode<T>)Right).Height;
        return leftHeight - rightHeight;
    }

    /// <summary>
    /// 更新节点高度
    /// </summary>
    public void UpdateHeight()
    {
        int leftHeight = Left == null ? 0 : ((AVLNode<T>)Left).Height;
        int rightHeight = Right == null ? 0 : ((AVLNode<T>)Right).Height;
        Height = 1 + Math.Max(leftHeight, rightHeight);
    }

    /// <summary>
    /// 节点左、右子树高度较高节点
    /// </summary>
    /// <returns>当前节点左 或 右节点</returns>
    public TreeNode<T> TallerChild()
    {
        int leftHeight = Left == null ? 0 : ((AVLNode<T>)Left).Height;
        int rightHeight = Right == null ? 0 : ((AVLNode<T>)Right).Height;

        if (leftHeight > rightHeight) return Left;
        if (leftHeight < rightHeight) return Right;
        return IsLeftChild() ? Left : Right;
    }
}
