using System;
using System.IO;

namespace AdventOfCode2020
{
    internal class SolutionDay1Challange1
    {
        public static void Run()
        {
            // Utils.FileRead();
            string[] data = Utils.FileRead();
            List <int> convertedData = IntListCreate(data);
            // foreach(int i in convertedData)
            //     Console.WriteLine(i+20);
            foreach (var value in convertedData)
            {
                if (convertedData.Contains(2020 - value))
                {
                    int secondElement = 2020 - value;
                    Console.WriteLine($"First Element {value}");
                    Console.WriteLine($"Second Element {secondElement}");
                    Console.WriteLine($"Answer: {value*secondElement}");
                    break;
                }

            }
            //
        }

        public static List<int> IntListCreate(string[] loadedData)
        {
            List<int> toReturn = new List<int>(loadedData.Length);
            foreach (string number in loadedData)
            {
                toReturn.Add(Convert.ToInt32(number));
            }
            //foreach(int a in toReturn) Console.WriteLine(a.GetType);
            return toReturn;
        }
    }

    static class Utils
    {
        public static string[] FileRead()
        {
            // Paste your own input
            int rows = File.ReadLines(@"C:\Przemek\Net and C#\AdventOfCode\Day1Challange1\input.txt").Count();
            string[] lines = new string[rows];
            int index = 0;
            // Paste your own input
            foreach (string row in File.ReadLines(@"C:\Przemek\Net and C#\AdventOfCode\Day1Challange1\input.txt"))
            {
                lines[index] = row.Trim();
                index++;
            }
            // foreach (string row in lines) Console.WriteLine(row);
            return lines;
        }
        public static List<int> ReadFile()
        {
            List<int> lines =
                new List<int>(
                    File.ReadLines(@"C:\Przemek\Net and C#\AdventOfCode\Day1Challange2\input.txt").Count());
            Console.WriteLine();
            foreach (string line in File.ReadLines(@"C:\Przemek\Net and C#\AdventOfCode\Day1Challange2\input.txt"))
            {
                // Console.WriteLine(line);
                lines.Add(int.Parse(line));
            }
            return lines;
        }
    }
}