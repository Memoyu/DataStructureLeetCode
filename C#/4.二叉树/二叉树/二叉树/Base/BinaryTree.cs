using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树.二叉树.Base;

public class BinaryTree<T>
{
    protected int _size;

    protected TreeNode<T> _root = null!;

    /// <summary>
    /// 获取二叉树根节点
    /// </summary>
    /// <returns></returns>
    public TreeNode<T> Root() => _root;

    /// <summary>
    /// 获取二叉树大小
    /// </summary>
    /// <returns></returns>
    public int Size() => _size;

    /// <summary>
    /// 二叉树是否为空
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => _size == 0;

    /// <summary>
    /// 是否为完全二叉树
    /// </summary>
    /// <returns></returns>
    public bool IsComplete()
    {
        // 同样采用层序遍历的形式进行校验

        // 如果树不为空，开始层序遍历二叉树（用队列）
        // 如果 node.left != null，将 node.left 入队
        // 如果 node.left == null && node.right != null，返回 false
        // 如果 node.right != null，将 node.right 入队
        // 如果 node.right == null
        //  ✓ 那么后面遍历的节点应该都为叶子节点，才是完全二叉树
        //  ✓ 否则返回 false
        // 遍历结束，返回 true
        if (_root == null) return false;
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(_root);
        bool leaf = false;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            // 如果标注了该状态，则说明接下来遍历的全是子节点，否则不为完全二叉树
            if (!node.IsLeaf()) return false;
            var ln = node.Left;
            var rn = node.Right;
            // 针对上述四种主要情况进行判断
            if (ln != null)
            {
                queue.Enqueue(ln);
            }
            else if (rn != null)
            {
                return false;
            }

            if (rn != null)
            {
                queue.Enqueue(rn);
            }
            else
            {
                // 第四种情况时，说明接下来的节点都为子节点才符合完全二叉树的要求，所以进行状态标注
                leaf = true;
            }

        }
        return true;
    }

    /// <summary>
    /// 使用迭代实现树的高度获取
    /// </summary>
    /// <returns></returns>
    public int HeightByIterate()
    {
        // 采用层序遍历的形式进行处理
        // 遍历到每一层的每一个节点，到最后一个节点时，进行下一层节点数的获取，并进行高度递增
        var height = 0;
        if (_root == null) return height;
        var levelSize = 1;// 存储层的节点数
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(_root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            levelSize--;// 每取出一个节点，就进行层节点数的递减
            var ln = node.Left;
            var rn = node.Right;
            if (ln != null) queue.Enqueue(ln);
            if (rn != null) queue.Enqueue(rn);// 将左右节点入队

            // 如果层节点遍历完了，则进行层数递增，并获取下一层的节点数(此时，queue中所有节点则为下一层的所有节点)
            if (levelSize == 0)
            {
                levelSize = queue.Count;
                height++;
            }
        }
        return height;
    }

    /// <summary>
    /// 使用递归实现树的高度获取
    /// </summary>
    /// <returns></returns>
    public int Height()
    {
        return Height(_root);
    }

    private int Height(TreeNode<T> node)
    {
        if (node == null) return 0;
        // 递归 比较树左右两边的高度，哪边高取哪边
        return 1 + Math.Max(Height(node.Left), Height(node.Right));
    }

    /// <summary>
    /// 创建节点
    /// </summary>
    /// <param name="value"></param>
    /// <param name="parentNode"></param>
    /// <returns></returns>
    protected virtual TreeNode<T> CreateNode(T value, TreeNode<T> parentNode)
    {
        return new TreeNode<T>(value, parentNode);
    }

    /// <summary>
    /// 清除二叉树
    /// </summary>
    public void Clear()
    {
        _root = null;
        _size = 0;
    }

    /// <summary>
    /// 前序遍历节点，根 -> 左 -> 右
    /// </summary>
    public void PreorderTraversal(Action<T> action)
    {
        if (action == null) return;

        //非递归
        PreorderTraversalNonRecursive(_root, action);
        // 递归
        // PreorderTraversal(_root, action);
    }

    /// <summary>
    /// 前序遍历-非递归版本
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    private void PreorderTraversalNonRecursive(TreeNode<T> node, Action<T> action)
    {
        // 可看示例图：https://www.yuque.com/memoyu/ezn2kr/xzxvwg#Olc23
        // 因为前序遍历顺序为：根 -> 左 -> 右；所以，在我们拿到根节点后，一直往左走（根 -> 左），同时将右子节点存入栈中，直到左子节点为空，此时再往右子节点找（取出栈数据）
        if (node == null) return;
        var stack = new Stack<TreeNode<T>>();
        while (true)
        {
            // 节点不为空时，则将其右节点入栈
            if (node != null)
            {
                action(node.Value); //做节点操作 
                stack.Push(node.Right); // 将右节点入栈
                node = node.Left; // 往根节点的右节点继续往下找
            }
            else // 节点为空时，则可能为节点遍历完成（栈中数据为空）或node的左子节点没了 
            {
                if (!stack.Any()) return; // 如果栈中没有了元素，说明遍历完了
                node = stack.Pop(); // 弹出栈顶的右节点，作为根节点，继续循环
            }
        }
    }

    /// <summary>
    /// 前序遍历-递归版本
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    private void PreorderTraversal(TreeNode<T> node, Action<T> action)
    {
        if (node == null) return;
        action(node.Value);
        PreorderTraversal(node.Left, action);
        PreorderTraversal(node.Right, action);
    }

    /// <summary>
    /// 中序遍历节点，左 -> 根 -> 右
    /// </summary>
    public void InorderTraversal(Action<T> action)
    {
        if (action == null) return;

        // 非递归
        IneorderTraversalNonRecursive(_root, action);

        // 递归
        // IneorderTraversal(_root, action);
    }

    /// <summary>
    /// 中序遍历-非递归版本
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    private void IneorderTraversalNonRecursive(TreeNode<T> node, Action<T> action)
    {
        //可看示例图：https://www.yuque.com/memoyu/ezn2kr/xzxvwg#BPwTQ
        // 因为中序遍历顺序为：左 -> 根 -> 右；所以，同样是拿到根节点后一直往左边遍历，并将遍历到的节点存入栈，直到最后节点为空时，从栈中弹出节点，并执行处理，然后将弹出节点的右节点拿出，进行下遍历
        if (node == null) return;
        var stack = new Stack<TreeNode<T>>();
        while (true)
        {
            // 节点不为空，则将其入栈，并获取其左节点，继续遍历
            if (node != null)
            {
                stack.Push(node);
                node = node.Left;
            }
            else // 为空时，则可能时栈中节点没了（遍历完成）或 node左子节点已经为空
            {
                if (!stack.Any()) return;
                node = stack.Pop(); // 此时，需要从栈中弹出节点
                action(node.Value); // 进行处理
                node = node.Right; // 并去除节点右子节点，进行下轮循环
            }
        }
    }

    /// <summary>
    /// 中序遍历-递归版本
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    private void IneorderTraversal(TreeNode<T> node, Action<T> action)
    {
        if (node == null) return;
        IneorderTraversal(node.Left, action);
        action(node.Value);
        IneorderTraversal(node.Right, action);
    }

    /// <summary>
    /// 后序遍历节点，左 -> 右 -> 根
    /// </summary>
    public void PostorderTraversal(Action<T> action)
    {
        if (action == null) return;
        //非递归
        PostorderTraversalNonRecursive(_root, action);
        // 递归
        // PostorderTraversal(_root, action);
    }

    /// <summary>
    /// 后序遍历-非递归版本
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    private void PostorderTraversalNonRecursive(TreeNode<T> node, Action<T> action)
    {
        //可看示例图：https://www.yuque.com/memoyu/ezn2kr/xzxvwg#SEo6m
        // 因为后序遍历节点，左 -> 右 -> 根；该方式以栈中节点为遍历依据，首先用根节点填充，然后循环内部对栈顶的元素进行处理，判断栈顶中节点是否为叶子节点 或 本次出栈节点是否为上次出栈节点的父节点，是则进行出栈，并处理，否则进行右、左子节点入栈
        if (node == null) return;
        var stack = new Stack<TreeNode<T>>();
        TreeNode<T> prev = null; // 记录上次出栈的节点
        stack.Push(node); // 先将根节点入栈
        while (stack.Any())
        {
            var top = stack.Peek();
            if (top.IsLeaf() || (prev != null && top == prev.Parent) ) // 如果是叶子节点，则进行出栈，进行处理
            {
                prev = stack.Pop();
                action(prev.Value);
            }
            else // 否则，不是叶子节点，则将该节点的右、左子节点进行入栈（顺序是必要的，因为后续遍历顺序为左、右、根，所以出栈对应左、右）
            {
                if (top.Right != null) // 如果存在右子节点，则进行入栈
                {
                    stack.Push(top.Right);
                }

                if (top.Left != null) // 如果存在左子节点，则进行入栈 
                {
                    stack.Push(top.Left);
                }

            }
        }
    }

    /// <summary>
    /// 后序遍历-递归版本
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    private void PostorderTraversal(TreeNode<T> node, Action<T> action)
    {
        if (node == null) return;
        PostorderTraversal(node.Left, action);
        PostorderTraversal(node.Right, action);
        action(node.Value);
    }

    /// <summary>
    /// 层序遍历
    /// </summary>
    public void LevelOrderTraversal(Action<T> action)
    {
        if (_root == null || action == null) return;
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(_root);
        while (queue.Count > 0)
        {
            // 从队列中出队节点，进行处理
            var node = queue.Dequeue();
            action.Invoke(node.Value);
            var ln = node.Left;
            var rn = node.Right;
            // 将左右节点进行入队
            if (ln != null) queue.Enqueue(ln);
            if (rn != null) queue.Enqueue(rn);
        }
    }

    /// <summary>
    /// 获取二叉树某个节点的前驱节点
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public TreeNode<T> Predecessor(TreeNode<T> node)
    {
        // 当节点的左节点不为空时
        if (node.Left != null)
        {
            TreeNode<T> predecessor = null;
            predecessor = node.Left;
            while (predecessor.Right != null)
            {
                predecessor = predecessor.Right;
            }

            return predecessor;
        }

        // 否则，左节点为空，则向上查找，直至parent为空或parent.Left == 当前节点
        while (node.Parent != null && node == node.Parent.Left)
        {
            node = node.Parent;
        }

        return node.Parent;
    }

    /// <summary>
    /// 获取二叉树某个节点的后继节点（实现为前驱节点的反向，则 Rigth->Left;Left->Rigth）
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public TreeNode<T> Successor(TreeNode<T> node)
    {
        if (node.Right != null)
        {
            TreeNode<T> predecessor = null;
            predecessor = node.Right;
            while (predecessor.Left != null)
            {
                predecessor = predecessor.Left;
            }

            return predecessor;
        }

        while (node.Parent != null && node == node.Parent.Right)
        {
            node = node.Parent;
        }

        return node.Parent;
    }

    /// <summary>
    /// 重写ToString
    /// </summary>
    /// <param name="node"></param>
    /// <param name="sb"></param>
    /// <param name="prefix"></param>
    public override string ToString()
    {
        var sb = new StringBuilder();
        ToString(_root, sb, "");
        return sb.ToString();
    }

    private void ToString(TreeNode<T> node, StringBuilder sb, string prefix)
    {
        if (node == null) return;
        sb.Append(prefix).Append(node.Value).Append("\r\n");
        ToString(node.Left, sb, $"{prefix}[L]");
        ToString(node.Right, sb, $"{prefix}[R]");
    }
}