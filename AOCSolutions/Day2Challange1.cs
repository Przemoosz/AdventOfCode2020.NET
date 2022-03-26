namespace AdventOfCode2020;

/*
Creator: Przemysław Szewczak
Date: 02.01.2022
Source: https://adventofcode.com/2020/day/2
Language: C#
 */

    public class SolutionDay2Challange1
    {
        public static void Run()
        {
            Solution input = new Solution();
        }
    }

    internal class Solution
    {
        public Solution()
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
            Dictionary<string, string> conditions = new Dictionary<string, string>(); 
            string[] lineComponenets = line.Split(' ');
            List<char> password = new List<char>(lineComponenets[2].Length);
            password.AddRange(lineComponenets[2].ToCharArray());
            conditions.Add("Min",lineComponenets[0].Split('-')[0]);
            conditions.Add("Max",lineComponenets[0].Split('-')[1]);
            conditions.Add("Key", lineComponenets[1].ToCharArray()[0].ToString());
            int count = 0;
            count = password.Count((char x) => x == Char.Parse(conditions["Key"]));
            if (count >= Int32.Parse(conditions["Min"]) && count <= Int32.Parse(conditions["Max"]))
            {
                // Console.WriteLine($"{lineComponenets[2]} -- Password correct");
                return true;
            }
            else return false;
        }
        
    }
