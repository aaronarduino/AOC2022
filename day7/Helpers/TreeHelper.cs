public static class TreeHelper
{
    public static int SizeByFolder(Node node)
    {
        int size = 0;
        foreach (Node n in node.Children)
        {

            size += SizeByFolder(n);
        }

        if (node.NodeType == "folder")
        {
            int nodeSize = node.Size();
            if (nodeSize < 100000)
            {
                //Console.WriteLine($"Type: {node.NodeType}, Name: {node.Name}, Size: {nodeSize}");
                size += nodeSize;
            }
        }

        return size;
    }

    public static List<Tuple<int, string>> FindFoldersBySize(Node node, int targetSize)
    {
        List<Tuple<int, string>> nodes = new List<Tuple<int, string>>();
        foreach (Node n in node.Children)
        {
            nodes.AddRange(FindFoldersBySize(n, targetSize));
        }

        if (node.NodeType == "folder")
        {
            int nodeSize = node.Size();
            if (nodeSize >= targetSize)
            {
                //Console.WriteLine($"Type: {node.NodeType}, Name: {node.Name}, Size: {nodeSize}");
                nodes.Add(new Tuple<int, string>(nodeSize, node.Name));
            }
        }

        return nodes;
    }
}
