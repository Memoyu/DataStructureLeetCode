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
    /// <param name="grand">grand必然是第一个发现不平衡的节点，故为高度最低的不平衡节点（因为是从创建节点一直往上找，一直往父节点找）</param>
    /// <see cref="AVL树-失衡后进行恢复">https://www.yuque.com/memoyu/ezn2kr/ssxw04</see>
    private void ReBalance(TreeNode<T> grand)
    {
        // 获取不平衡节点node下左右高度最高子树的根节点，以及该节点下左右高度最高子树的根节点；
        var parent = ((AVLNode<T>)grand).TallerChild();
        var node = ((AVLNode<T>)parent).TallerChild();

        #region 方案1：根据路径不同，进行不同处理

        /*// 通过判断失衡节点的位置，确定恢复（旋转）方案（LL、LR、RL、RR参考注释文档）
        if (parent.IsLeftChild()) // L
        {
            if (node.IsLeftChild()) // LL - 右旋转
            {
                RotateRight(grand);
            }
            else // LR - 左旋转，右旋转
            {
                RotateLeft(parent);
                RotateRight(grand);
            }
        }
        else // R
        {
            if (node.IsLeftChild()) // RL - 右旋转，左旋转
            {
                RotateRight(parent);
                RotateLeft(grand);
            }
            else // RR
            {
                RotateLeft(parent);
            }
        }*/

        #endregion

        #region 方案2：根据结果特征，统一操作

        if (parent.IsLeftChild()) // L
        {
            if (node.IsLeftChild()) // LL - 右旋转
            {
                Rotate(grand, node, node.Right, parent, parent.Right, grand);
            }
            else // LR - 左旋转，右旋转
            {
                Rotate(grand, parent, node.Left, node, node.Right, grand);
            }
        }
        else // R
        {
            if (node.IsLeftChild()) // RL - 右旋转，左旋转
            {
                Rotate(grand, grand, node.Left, node, node.Right, parent);
            }
            else // RR
            {
                Rotate(grand, grand, parent.Left, parent, node.Left, node);
            }
        }

        #endregion
    }

    #region 方案1：根据路径不同，进行不同处理

    /// <summary>
    /// 左旋转
    /// </summary>
    /// <param name="grand"></param>
    private void RotateLeft(TreeNode<T> grand)
    {
        // 这里涉及两个节点位置的调整，分别为grand、grand.Right；
        // 让grand.Right上升一层，成为grand的父节点
        // 让   grand   下降一层，成为grand.Right的左节点

        // 调整两个节点的层级关系
        var parent = grand.Right;
        var node = parent.Left;
        grand.Right = node;
        parent.Left = grand;

        AfterRotate(grand, parent, node);
        // 左、右旋转后此处后续维护工作一致
        // 维护旋转影响节点的parent
        parent.Parent = grand.Parent;
        if (grand.IsLeftChild())
        {
            grand.Parent.Left = parent;
        }
        else if (grand.IsRightChild())
        {
            grand.Parent.Right = parent;
        }
        else // 来到这，说明node是root
        {
            _root = parent;
        }

        // 可能node为空，因为parent的 左子树 可能为空
        if (node != null)
            node.Parent = grand;
        grand.Parent = parent;

        // 更新节点高度
        UpdateHeight(grand);
        UpdateHeight(parent);
    }

    /// <summary>
    /// 右旋转
    /// </summary>
    /// <param name="grand"></param>
    private void RotateRight(TreeNode<T> grand)
    {
        // 这里涉及两个节点位置的调整，分别为grand、grand.Left；
        // 让grand.Left上升一层，成为grand的父节点
        // 让   grand  下降一层，成为grand.Left的右节点

        // 调整两个节点的层级关系
        var parent = grand.Left;
        var node = parent.Right;
        grand.Left = node;
        parent.Right = grand;

        AfterRotate(grand, parent, node);
        // 左、右旋转后此处后续维护工作一致
        // 维护旋转影响节点的parent
        parent.Parent = grand.Parent;
        if (grand.IsLeftChild())
        {
            grand.Parent.Left = parent;
        }
        else if (grand.IsRightChild())
        {
            grand.Parent.Right = parent;
        }
        else // 来到这，说明grand是root
        {
            _root = parent;
        }

        // 可能node为空，因为parent的 右子树 可能为空
        if (node != null)
            node.Parent = grand;

        grand.Parent = parent;

        // 更新节点高度
        UpdateHeight(grand);
        UpdateHeight(parent);
    }

    /// <summary>
    /// 旋转节点后的维护操作：维护涉及节点的parent等属性值
    /// </summary>
    /// <param name="grand">层级下降节点</param>
    /// <param name="parent">层级上升节点</param>
    /// <param name="node">层级上升节点的子节点</param>
    private void AfterRotate(TreeNode<T> grand, TreeNode<T> parent, TreeNode<T> node)
    {
        parent.Parent = grand.Parent;
        if (grand.IsLeftChild())
        {
            grand.Parent.Left = parent;
        }
        else if (grand.IsRightChild())
        {
            grand.Parent.Right = parent;
        }
        else // 来到这，说明grand是root
        {
            _root = parent;
        }

        // 可能node为空，因为parent的 左子树 可能为空
        if (node != null)
            node.Parent = grand;
        grand.Parent = parent;

        // 更新节点高度
        UpdateHeight(grand);
        UpdateHeight(parent);
    }

    #endregion

    #region 方案2：根据结果特征，统一操作

    /// <summary>
    /// 统一旋转节点操作(源于从分析图中可知，b.Left、f.Right旋转前后都是保持不变的，故 a、g 无需传入)
    /// </summary>
    /// <param name="r">不平衡子树根节点, </param>
    /// <param name="b">分块b</param>
    /// <param name="c">分块c</param>
    /// <param name="d">分块d</param>
    /// <param name="e">分块e</param>
    /// <param name="f">分块f</param>
    private void Rotate(
        TreeNode<T> r,
        TreeNode<T> b, TreeNode<T> c, TreeNode<T> d, TreeNode<T> e, TreeNode<T> f)
    {
        d.Parent = r.Parent;
        if (r.IsLeftChild())
        {
            r.Parent.Left = d;
        }
        else if (r.IsRightChild())
        {
            r.Parent.Right = d;
        }
        else
        {
            _root = d;
        }

        // 处理 a - b - c 节点间的关系
        // 反转前后，b的left始终是a ，故不用调整
        // b.Left = a;
        // if (a != null) a.Parent = b;
        b.Right = c;
        if (c != null) c.Parent = b;
        UpdateHeight(b);

        // 处理 e - f - g 节点间的关系
        f.Left = e;
        if (e != null) e.Parent = f;
        // 反转前后，f的right始终是g ，故不用调整
        // f.Right = g;
        // if (g != null) g.Parent = f;
        UpdateHeight(f);

        // 处理 d - b - f 节点间的关系
        d.Left = b;
        d.Right = f;
        b.Parent = d;
        f.Parent = d;
        UpdateHeight(d);
    }

    #endregion
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
