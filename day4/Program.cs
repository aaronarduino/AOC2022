using AOCHelper;

var reader = new FileReader("", "input.txt", "test.txt");
List<string>? input = reader.ReadLines();

if (input != null)
{
    // Part 1
    int countPart1 = 0;
    int countPart2 = 0;

    foreach (var line in input)
    {
        // 1. Split at ","
        var splitLine = line.Split(",").ToList();
        string pair1 = splitLine[0];
        string pair2 = splitLine[1];

        // 2. Split at "-"
        var splitPair1 = pair1.Split("-").ToList();
        var splitPair2 = pair2.Split("-").ToList();

        // 2. Convert to numbers
        int pair1Lower = Convert.ToInt32(splitPair1[0]);
        int pair1Higher = Convert.ToInt32(splitPair1[1]);
        int pair2Lower = Convert.ToInt32(splitPair2[0]);
        int pair2Higher = Convert.ToInt32(splitPair2[1]);

        // 3. Check for inclusive ranges
        if ((pair1Lower <= pair2Lower && pair2Higher <= pair1Higher) ||
            (pair2Lower <= pair1Lower && pair1Higher <= pair2Higher))
        {
            countPart1++;
        }

        // 4. Check for any overlap
        if ((pair1Lower >= pair2Lower && pair1Lower <= pair2Higher) ||
            (pair1Higher >= pair2Lower && pair1Higher <= pair2Higher) ||
            (pair2Lower >= pair1Lower && pair2Lower <= pair1Higher) ||
            (pair2Higher >= pair1Lower && pair2Higher <= pair1Higher))
        {
            countPart2++;
        }
    }

    Console.WriteLine(countPart1);
    Console.WriteLine(countPart2);
}
