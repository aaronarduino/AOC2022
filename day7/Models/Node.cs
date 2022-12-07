public class Node
{
    public string Name { get; set; } = default!;
    public string NodeType { get; set; } = default!;
    public int? _size { get; set; }
    public Node? ParentNode { get; set; } = default!;
    public List<Node> Children { get; set; } = new List<Node>();


    public int Size()
    {
        int size = _size.HasValue ? _size.Value : 0;

        foreach (var item in Children)
        {
            size += item.Size();
        }
        return size;
    }
}
