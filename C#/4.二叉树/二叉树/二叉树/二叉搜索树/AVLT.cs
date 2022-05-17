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
    /// <see cref="AVL树-失衡后进行恢复">https://www.yuque.com/memoyu/ezn2kr/ssxw04</see>
    private void ReBalance(TreeNode<T> node)
    {
        // 获取不平衡节点node下左右高度最高子树的根节点，以及该节点下左右高度最高子树的根节点；
        var nodeChild = ((AVLNode<T>)node).TallerChild();
        var nodeSecChild = ((AVLNode<T>)nodeChild).TallerChild();

        // 通过判断失衡节点的位置，确定恢复（旋转）方案（LL、LR、RL、RR参考注释文档）
        if (nodeChild.IsLeftChild()) // L
        {
            if (nodeSecChild.IsLeftChild()) // LL - 右旋转
            {
                RotateRight(node);
            }
            else // LR - 左旋转，右旋转
            {
                RotateLeft(nodeChild);
                RotateRight(node);
            }
        }
        else // R
        {
            if (nodeSecChild.IsLeftChild()) // RL - 右旋转，左旋转
            {
                RotateRight(nodeChild);
                RotateLeft(node);
            }
            else // RR
            {
                RotateLeft(nodeChild);
            }
        }
    }

    /// <summary>
    /// 左旋转
    /// </summary>
    /// <param name="nodeDown"></param>
    private void RotateLeft(TreeNode<T> nodeDown)
    {
        // 这里涉及两个节点位置的调整，分别为node、node.Right；
        // 让node.Right上升一层，成为node的父节点
        // 让   node   下降一层，成为node.Right的左节点

        // 调整两个节点的层级关系
        var nodeUp = nodeDown.Right;
        var nodeUpLeftChild = nodeUp.Left;
        nodeDown.Right = nodeUpLeftChild;
        nodeUp.Left = nodeDown;

        AfterRotate(nodeDown, nodeUp, nodeUpLeftChild);
        /* 左、右旋转后此处后续维护工作一致
        // 维护旋转影响节点的parent
        nodeUp.Parent = nodeDown.Parent;
        if (nodeDown.IsLeftChild())
        {
            nodeDown.Parent.Left = nodeUp;
        }
        else if (nodeDown.IsRightChild())
        {
            nodeDown.Parent.Right = nodeUp;
        }
        else // 来到这，说明node是root
        {
            _root = nodeUp;
        }

        // 可能nodeUpRightChild为空，因为nodeUp的 左子树 可能为空
        if (nodeUpLeftChild != null)
            nodeUpLeftChild.Parent = nodeDown;
        nodeDown.Parent = nodeUp;

        // 更新节点高度
        UpdateHeight(nodeDown);
        UpdateHeight(nodeUp);*/
    }

    /// <summary>
    /// 旋转节点后的维护操作：维护涉及节点的parent等属性值
    /// </summary>
    /// <param name="nodeDown">层级下降节点</param>
    /// <param name="nodeUp">层级上升节点</param>
    /// <param name="nodeUpChild">层级上升节点的子节点</param>
    private void AfterRotate(TreeNode<T> nodeDown, TreeNode<T> nodeUp, TreeNode<T> nodeUpChild)
    {
        nodeUp.Parent = nodeDown.Parent;
        if (nodeDown.IsLeftChild())
        {
            nodeDown.Parent.Left = nodeUp;
        }
        else if (nodeDown.IsRightChild())
        {
            nodeDown.Parent.Right = nodeUp;
        }
        else // 来到这，说明node是root
        {
            _root = nodeUp;
        }

        // 可能nodeUpRightChild为空，因为nodeUp的 左子树 可能为空
        if (nodeUpChild != null)
            nodeUpChild.Parent = nodeDown;
        nodeDown.Parent = nodeUp;

        // 更新节点高度
        UpdateHeight(nodeDown);
        UpdateHeight(nodeUp);
    }

    /// <summary>
    /// 右旋转
    /// </summary>
    /// <param name="node"></param>
    private void RotateRight(TreeNode<T> nodeDown)
    {
        // 这里涉及两个节点位置的调整，分别为node、node.Left；
        // 让node.Left上升一层，成为node的父节点
        // 让   node  下降一层，成为node.Left的右节点

        // 调整两个节点的层级关系
        var nodeUp = nodeDown.Left;
        var nodeUpRightChild = nodeUp.Right;
        nodeDown.Left = nodeUpRightChild;
        nodeUp.Right = nodeDown;

        AfterRotate(nodeDown, nodeUp, nodeUpRightChild);
        // 左、右旋转后此处后续维护工作一致
        // 维护旋转影响节点的parent
        nodeUp.Parent = nodeDown.Parent;
        if (nodeDown.IsLeftChild())
        {
            nodeDown.Parent.Left = nodeUp;
        }
        else if (nodeDown.IsRightChild())
        {
            nodeDown.Parent.Right = nodeUp;
        }
        else // 来到这，说明node是root
        {
            _root = nodeUp;
        }

        // 可能nodeUpRightChild为空，因为nodeUp的 右子树 可能为空
        if (nodeUpRightChild != null)
            nodeUpRightChild.Parent = nodeDown;

        nodeDown.Parent = nodeUp;

        // 更新节点高度
        UpdateHeight(nodeDown);
        UpdateHeight(nodeUp);
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
