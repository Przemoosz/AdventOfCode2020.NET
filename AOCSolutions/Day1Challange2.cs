namespace AdventOfCode2020;

internal class SolutionDay1Challange2
{
    public static void Run()
    {
        long solution = 0;
        Console.WriteLine();
        // Utils.ReadFile();
        solution = Solution(Utils.ReadFile());
        Console.WriteLine($"Solution to day 1 Challange 2: {solution}");
    }

    public static long Solution(List<int> numbers)
    {
        long result = 0;
        bool breakfor = false;
        foreach (int number in numbers)
        {
            int searchingNumber = 2020 - number;
            foreach (int innernumber in numbers)
            {
                if (numbers.Contains(searchingNumber - innernumber))
                {
                    // Console.WriteLine($"{number} -- {innernumber} -- {searchingNumber-innernumber}");
                    result = number * innernumber * (searchingNumber - innernumber);
                    breakfor = true;
                    break;
                }
            }
            if (breakfor)
            {
                break;
            }
        }

        return result;
    }
}