using 二叉树.二叉树.Base;

namespace 二叉树;

public class _226_翻转二叉树
{
    public static TreeNode<int> InvertTreePreorder(TreeNode<int> root)
    {
        if (root == null) return root;

        var tempLeft = root.Left;
        root.Left = root.Right;
        root.Right = tempLeft;

        InvertTreePreorder(root.Left);
        InvertTreePreorder(root.Right);

        return root;
    }

    public static TreeNode<int> InvertTreeInorder(TreeNode<int> root)
    {
        if (root == null) return root;

        InvertTreeInorder(root.Left);

        var tempLeft = root.Left;
        root.Left = root.Right;
        root.Right = tempLeft;

        // 此时，我们需要反转的是Right，并且在此之前，Left与Right已经交换，故此处应该传入Left
        InvertTreeInorder(root.Left);

        return root;
    }

    public static TreeNode<int> InvertTreePostorder(TreeNode<int> root)
    {
        if (root == null) return root;

        InvertTreePreorder(root.Left);
        InvertTreePreorder(root.Right);

        var tempLeft = root.Left;
        root.Left = root.Right;
        root.Right = tempLeft;

        return root;
    }

    public static TreeNode<int> InvertTreeLevelOrder(TreeNode<int> root)
    {
        if (root == null) return root;

        Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var ln = node.Left;
            var rn = node.Right;
            node.Left = rn;
            node.Right = ln;

            if (ln != null)
            {
                queue.Enqueue(ln);
            }

            if (rn != null)
            {
                queue.Enqueue(rn);
            }
        }    

        return root;
    }


}
