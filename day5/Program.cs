using AOCHelper;

var reader = new FileReader("", "input.txt", "test.txt");
List<string>? input = reader.ReadLines();

if (input != null)
{
    Dictionary<string, Stack<string>> stacks = new Dictionary<string, Stack<string>>();
    List<string> rawStacks = new List<string>();
    List<string> instructions = new List<string>();
    List<Tuple<int, string>> stackLocations = new List<Tuple<int, string>>();

    bool endOfStack = false;

    foreach (var line in input)
    {
        //
        if (line == string.Empty)
        {
            endOfStack = true;
            continue;
        }

        if (!endOfStack)
        {
            rawStacks.Add(line);
        }
        else
        {
            instructions.Add(line);
        }
    }

    rawStacks.Reverse();
    //rawStacks.ForEach(s => Console.WriteLine(s));

    string firstLine = rawStacks[0];

    List<string> splitLine = new List<string>();

    for (int i = 0; i <= firstLine.Length; i++)
    {
        string c = i < firstLine.Length ? firstLine[i].ToString() : string.Empty;
        if (!(c == " " || c == string.Empty))
        {
            stackLocations.Add(new Tuple<int, string>(i, c));
            stacks.Add(c, new Stack<string>());
        }
    }

    for (int h = 1; h < rawStacks.Count; h++)
    {
        var line = rawStacks[h];
        foreach (var stack in stackLocations)
        {
            char c = line[stack.Item1];
            if (c != ' ')
            {
                stacks[stack.Item2].Push(c.ToString());
            }
        }
    }

    foreach (string set in instructions)
    {
        List<string> splitInstruction = set.Split(' ').ToList();
        int count = Convert.ToInt32(splitInstruction[1]);
        string fromLoc = splitInstruction[3];
        string toLoc = splitInstruction[5];
        Stack<string> holding = new Stack<string>();

        for (int t = 0; t < count; t++)
        {
            holding.Push(stacks[fromLoc].Pop());
        }

        foreach (var item in holding)
        {
            stacks[toLoc].Push(item);
        }
    }

    stackLocations.ForEach(sl => Console.Write(stacks[sl.Item2].Peek()));
}
