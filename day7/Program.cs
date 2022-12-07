using AOCHelper;

var reader = new FileReader("", "input.txt", "test.txt");
List<string>? input = reader.ReadLines();

if (input != null)
{
    // Populate filesytem tree
    Node root = new Node() { Name = "/", NodeType = "folder" };
    Node currentNode = root;

    foreach (var line in input)
    {
        var splitLine = line.Split(' ').ToList();

        switch (splitLine[0])
        {
            case "$":
                //Console.WriteLine("comand");
                if (splitLine[1] == "cd")
                {
                    if (splitLine[2] == "/")
                    {
                        Console.WriteLine("Found Root Folder");
                    }
                    else if (splitLine[2] == "..")
                    {
                        currentNode = currentNode?.ParentNode ?? new Node();
                    }
                    else
                    {
                        Node? next = currentNode?.Children.Find(n => n.Name == splitLine[2]);
                        if (next != null)
                        {
                            currentNode = next;
                        }
                        else
                        {
                            Console.WriteLine("Could not find folder.");
                            Environment.Exit(1);
                        }
                    }
                }
                break;
            case "dir":
                //Console.WriteLine("folder");
                Node newFolderNode = new Node() { Name = splitLine[1], NodeType = "folder", ParentNode = currentNode };
                currentNode?.Children.Add(newFolderNode);
                break;
            default:
                //Console.WriteLine("file");
                Node newFileNode = new Node() { Name = splitLine[1], NodeType = "file", ParentNode = currentNode, _size = Convert.ToInt32(splitLine[0]) };
                currentNode?.Children.Add(newFileNode);
                break;
        }

    }

    // Part 1 - Walk tree and sum the sizes
    Console.WriteLine(TreeHelper.SizeByFolder(root));

    // Part 2 - Find folder to delete
    const int filesytemSize = 70000000;
    const int targetUnusedSize = 30000000;

    int targetDeleteSize = targetUnusedSize - (filesytemSize - root.Size());
    Console.WriteLine($"Target delete size: {targetDeleteSize}");

    var nodes = TreeHelper.FindFoldersBySize(root, targetDeleteSize);
    nodes.OrderBy(n => n.Item1);

    Console.WriteLine(nodes.FirstOrDefault()?.Item1);
}
