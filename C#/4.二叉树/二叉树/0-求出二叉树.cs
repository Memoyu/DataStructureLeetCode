using static 二叉树.实现二叉搜索树.BinarySearchTree<string>;

namespace 二叉树;

public class _0_求出二叉树
{
    // 已知前序、中序遍历结果，求出后序遍历的结果
    public static string GetPostorder(string preorder, string inorder)
    {
        var r = RefactorBinaryTreeByPI(preorder.Split(",").ToList(), inorder.Split(",").ToList());
        var nodes = new List<string>();
        PostorderTraversal(r, val =>
        {
            nodes.Add(val.ToString());
        });

        return string.Join(",", nodes);
    }

    private static Node<string> RefactorBinaryTreeByPI(List<string> preorder, List<string> inorder)
    {
        var root = preorder.FirstOrDefault();

        var left = new List<string>();
        var right = new List<string>();
        var pLeft = new List<string>();
        var pRight = new List<string>();
        var isLeft = true;
        foreach (var item in inorder)
        {
            if (item.Equals(root))
            {
                isLeft = false;
                continue;
            }
            if (isLeft)
            {
                left.Add(item);
            }
            else
            {
                right.Add(item);
            }
        }

        for (int i = 1; i < preorder.Count; i++)
        {
            if (i <= left.Count)
            {
                pLeft.Add(preorder[i]);
            }
            else
            {
                pRight.Add(preorder[i]);
            }
        }

        Node<string> node = new Node<string>(root, null);
        if (pLeft == null || !left.Any()) return node;
        node.Left = RefactorBinaryTreeByPI(pLeft, left);
        if (pRight == null || !right.Any()) return node;
        node.Right = RefactorBinaryTreeByPI(pRight, right);

        return node;
    }

    private static void PostorderTraversal(Node<string> node, Action<string> action)
    {
        if (node == null) return;
        PostorderTraversal(node.Left, action);
        PostorderTraversal(node.Right, action);
        action(node.Value);
    }

    // 已知中序、后序遍历结果，求出后序遍历的结果
    public static string GetPreorder(string inorder, string postorder)
    {
        var r = RefactorBinaryTreeByIP(inorder.Split(",").ToList(), postorder.Split(",").ToList());
        var nodes = new List<string>();
        PreorderTraversal(r, val =>
        {
            nodes.Add(val.ToString());
        });

        return string.Join(",", nodes);
    }

    private static Node<string> RefactorBinaryTreeByIP(List<string> inorder, List<string> postorder)
    {
        var root = postorder.LastOrDefault();

        var left = new List<string>();
        var right = new List<string>();
        var pLeft = new List<string>();
        var pRight = new List<string>();
        var isLeft = true;
        foreach (var item in inorder)
        {
            if (item.Equals(root))
            {
                isLeft = false;
                continue;
            }
            if (isLeft)
            {
                left.Add(item);
            }
            else
            {
                right.Add(item);
            }
        }

        for (int i = 0; i < postorder.Count - 1; i++)
        {
            if (i < left.Count)
            {
                pLeft.Add(postorder[i]);
            }
            else
            {
                pRight.Add(postorder[i]);
            }
        }

        Node<string> node = new Node<string>(root, null);
        if (pLeft == null || !left.Any()) return node;
        node.Left = RefactorBinaryTreeByIP(left, pLeft);
        if (pRight == null || !right.Any()) return node;
        node.Right = RefactorBinaryTreeByIP(right, pRight);

        return node;
    }

    private static void PreorderTraversal(Node<string> node, Action<string> action)
    {
        if (node == null) return;
        action(node.Value);
        PreorderTraversal(node.Left, action);
        PreorderTraversal(node.Right, action);
    }
}
