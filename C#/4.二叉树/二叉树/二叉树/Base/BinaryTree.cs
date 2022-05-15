using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树.二叉树.Base
{
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
        /// 清除二叉树
        /// </summary>
        public void Clear()
        {
            _root = null;
            _size = 0;
        }

        /// <summary>
        /// 前序遍历节点
        /// </summary>
        public void PreorderTraversal(Action<T> action)
        {
            if (action == null) return;
            PreorderTraversal(_root, action);
        }

        private void PreorderTraversal(TreeNode<T> node, Action<T> action)
        {
            if (node == null) return;
            action(node.Value);
            PreorderTraversal(node.Left, action);
            PreorderTraversal(node.Right, action);
        }

        /// <summary>
        /// 中序遍历节点
        /// </summary>
        public void InorderTraversal(Action<T> action)
        {
            if (action == null) return;
            IneorderTraversal(_root, action);
        }

        private void IneorderTraversal(TreeNode<T> node, Action<T> action)
        {
            if (node == null) return;
            IneorderTraversal(node.Left, action);
            action(node.Value);
            IneorderTraversal(node.Right, action);
        }

        /// <summary>
        /// 后序遍历节点
        /// </summary>
        public void PostorderTraversal(Action<T> action)
        {
            if (action == null) return;
            PostorderTraversal(_root, action);
        }

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
}
