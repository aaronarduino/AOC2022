using AOCHelper;

var reader = new FileReader("", "input.txt", "test.txt");
string? input = reader.ReadAll();

if (input != null)
{
    const int WINDOW_SIZE = 14;

    for (int i = 0; i < input.Length - WINDOW_SIZE; i++)
    {
        char[] window = new char[WINDOW_SIZE];

        for (int j = i; j < i + WINDOW_SIZE; j++)
        {
            window[j - i] = input[j];
        }

        var deduped = window.Distinct();
        if (deduped.Count() == WINDOW_SIZE)
        {
            Console.WriteLine(i + WINDOW_SIZE);
            System.Environment.Exit(0);
        }
    }
}

