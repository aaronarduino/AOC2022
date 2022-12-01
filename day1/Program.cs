using day1.Services;

var reader = new FileReader("", "input.txt", "test.txt");
List<string>? input = reader.ReadLines();

if (input != null)
{
    input.Add("");
    int current = 0;
    int third = 0;
    int second = 0;
    int first = 0;

    foreach (var line in input)
    {
        if (line.Length > 0)
        {
            current += Convert.ToInt32(line);
        }
        else
        {
            if (current > first)
            {
                third = second;
                second = first;
                first = current;
            }
            else if (current > second && current != first)
            {
                third = second;
                second = current;
            }
            else if (current > third && current != second)
            {
                third = current;
            }
            current = 0;
        }
    }

    Console.WriteLine(first + second + third);
}
