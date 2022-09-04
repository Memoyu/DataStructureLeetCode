namespace 并查集;

public class GenericUnionFind<T>
{
    private Dictionary<T, Node<T>> _nodes = new();

    public void MakeSet(T v)
    {
        if (_nodes.ContainsKey(v)) return;
        _nodes.Add(v, new Node<T>(v));
    }

    public T? Find(T v)
    {
        var node = FindNode(v);
        return node == null ? default : node.Value;
    }

    private Node<T>? FindNode(T v)
    {
        var exist = _nodes.TryGetValue(v, out Node<T> node);
        if (!exist) return null;
        while (!Equals(node.Value, node.Parent.Value))
        {
            node.Parent = node.Parent.Parent;
            node = node.Parent;
        }

        return node;
    }

    public void Union(T v1, T v2)
    {
        var p1 = FindNode(v1);
        var p2 = FindNode(v2);
        if (p1 == null || p2 == null) return;
        if (Equals(p1.Value, p2.Value)) return;

        if (p1.Rank < p2.Rank)
        {
            p1.Parent = p2;
        }
        else if (p1.Rank > p2.Rank)
        {
            p2.Parent = p1;
        }
        else
        {
            p1.Parent = p2;
            p2.Rank++;
        }
    }

    public bool IsSame(T v1, T v2)
    {
        return Equals(Find(v1), Find(v2));
    }

    private class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public int Rank { get; set; }

        public Node( T value)
        {
            Value = value;
            Parent = this;
        }
    }
}