namespace AdventOfCode2020;
using System.IO;

/*
Creator: Przemysław Szewczak
Date: 02.01.2022
Source: https://adventofcode.com/2020/day/2
Language: C#
*/
    public class SolutionDay2Challange2
    {
        public static void Run()
        {
            Solution2 input = new Solution2();
        }
    }

    public class Solution2
    {
        public Solution2()
        {
            FileRead();
        }

        private void FileRead()
        {
            // File read private method for Solution object
            int correct = 0;
            foreach (string line in
                     File.ReadLines(@"C:\Przemek\Net and C#\AdventOfCode\Day2Challange1\input.txt"))
            {
                if (LineOperation(line.Trim()))
                {
                    correct++;
                }
            }
            Console.WriteLine($"Correct passwords {correct}");
        }

        private bool LineOperation(string line)
        {
            // Performing line operations such as splitting, and validating data
            string[] lineComponenets = line.Split(' ');
            char[] passwordLetters = lineComponenets[2].ToCharArray();
            char key = Char.Parse(lineComponenets[1].ToCharArray()[0].ToString());
            int minPos = Int32.Parse(lineComponenets[0].Split('-')[0])-1;
            int maxPos = Int32.Parse(lineComponenets[0].Split('-')[1])-1;
            // Using logical Exclusive OR (XOR) to solve problem  
            if (passwordLetters[minPos] == key ^ passwordLetters[maxPos] == key)
            {
                // Console.WriteLine(lineComponenets[2]);
                return true;
                
            }
            else return false;
            //else return false;
        }
        
    }
