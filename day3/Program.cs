using AOCHelper;

var reader = new FileReader("", "input.txt", "test.txt");
List<string>? input = reader.ReadLines();

List<char> priorities = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

if (input != null)
{
    // Part 1
    int total = 0;

    foreach (var line in input)
    {
        var chunked = line.Chunk(line.Length / 2).ToList();

        string firstComp = new string(chunked[0]);
        string secondComp = new string(chunked[1]);

        var diff = firstComp.Intersect(secondComp).ToList();
        char commonChar = diff[0];

        int commonCharPriority = priorities.IndexOf(commonChar) + 1;

        total += commonCharPriority;
    }

    Console.WriteLine(total);

    total = 0;

    // Part 2
    int count = 1;

    string first = "";
    string second = "";
    string third = "";

    foreach (var line in input)
    {
        if (count == 3)
        {
            third = line;

            string firstTwo = new string(first.Intersect(second).ToArray());
            var diff = firstTwo.Intersect(third).ToList();
            char commonChar = diff[0];

            int commonCharPriority = priorities.IndexOf(commonChar) + 1;

            total += commonCharPriority;
            count = 0;
        }
        else if (count == 2)
        {
            second = line;
        }
        else if (count == 1)
        {
            first = line;
        }
        count++;
    }

    Console.WriteLine(total);
}
