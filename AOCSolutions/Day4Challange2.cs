using System.Text.RegularExpressions;

namespace AdventOfCode2020;

internal class Day4Challange2
{
    public static void Run()
    {
        Solution sol = Solution.GetInstance();
        sol.Start();
    }

    private sealed class Solution
    {
        // Creating Singleton Design Pattern
        private Solution()
        {
            
        }

        private static Solution? _solution = null;

        public static Solution GetInstance()
        {
            if (_solution is null)
            {
                _solution = new Solution();
            }

            return _solution;
        }

        private static int _count=0;
        public void Start()
        {
            ReadFile();
            // Console.WriteLine("Dsdsd");
        }

        private void ReadFile()
        {
            string path = Directory.GetCurrentDirectory() + "\\input.txt";
            using (FileStream stream = File.OpenRead(path))
            {
                if (stream.CanRead)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line;
                        Dictionary<string, string> passportDictionary = new Dictionary<string, string>(16);
                        // reader.
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine().Trim();
                            if (line == "")
                            {
                                if (ValidationCheck(passportDictionary)) _count++;
                                passportDictionary.Clear();
                                passportDictionary.EnsureCapacity(16);
                                continue;
                            }
                            foreach (string key in line.Split(" "))
                            {
                                // Console.WriteLine(key);
                                passportDictionary.Add(key.Split(":")[0], key.Split(":")[1]);
                            }
                            
                        }

                        if(ValidationCheck(passportDictionary)) _count++;

                        Console.WriteLine(_count);
                    }
                }
                
            }
        }

        private static bool ValidationCheck(Dictionary<string, string> dict)
        {
            if (dict.Count != 8)
            {
                if (!(dict.Count == 7 && !dict.ContainsKey("cid")))
                {
                    // Console.WriteLine("False");
                    return false; 
                }
            }
            if(!(Validation.YearCheck(dict["byr"],1920,2002) && Validation.YearCheck(dict["iyr"],2010,2020) && Validation.YearCheck(dict["eyr"],2020,2030)))
            {
                return false;
            }

            if (!Validation.HeightCheck(dict["hgt"]))
            {
                // Console.WriteLine("Not fine");
                return false;
            }

            if (!Validation.HairColorCheck(dict["hcl"]))
            {
                return false;
            }

            if (!Validation.PassportCheck(dict["pid"]))
            {
                return false;
            }

            if (!Validation.EyeColorCheck(dict["ecl"]))
            {
                return false;
            }

            return true;
        }
        
    }
}

public sealed class Validation
{
    public static bool YearCheck(string toParse, int least, int most)
        {
            if (Int32.TryParse(toParse, out int year))
            {
                if ((year >= least && year <= most)) return true;
                // Console.WriteLine($"{year} -- fine");
                return false;
            }

            return false;
        }

        public static bool HeightCheck(string height)
        {
            if (height.Length < 2)
            {
                return false;
            }
            bool isCm;
            if (height.Substring(height.Length - 2).Equals("cm"))
            {
                isCm = true;
            }
            else if (height.Substring(height.Length - 2).Equals("in"))
            {
                isCm = false;
            }
            else
            {
                return false;
            }
            // return true;
            if (isCm && Int32.TryParse(height.Substring(0,3), out int hgt ))
            {
                if (hgt >= 150 && hgt < 194)
                {
                    return true;
                }

                return false;
            }
            else if (!isCm && Int32.TryParse(height.Substring(0,2), out int hgtin ))
            {
                if (hgtin >= 59 && hgtin < 77)
                {
                    return true;
                }
                return false;
            }

            return false;

        }

        public static bool HairColorCheck(string hair)
        {
            string regexPattern = @"[^a-f0-9]+";
            Regex regex = new Regex(regexPattern);
            string colour = hair.Substring(1);
            Console.WriteLine(colour);
            if (colour.Length != 6 || regex.IsMatch(colour))
            {
                Console.WriteLine("Illegal");
                return false;
            }
            // Console.WriteLine("Legal");
            return true;
            
        }

        public static bool PassportCheck(string passport)
        {
            if (passport.Length != 9)
            {
                return false;
            }

            string regexPattern = @"[^0-9]";
            Regex regex = new Regex(regexPattern);
            Console.WriteLine(regex.IsMatch(passport));

            if (!regex.IsMatch(passport))
            {
                // Console.WriteLine("Fine");
                return true;
            }
            // Console.WriteLine(regex.IsMatch(passport));
            return false;
        }

        public static bool EyeColorCheck(string eyeColor)
        {
            if (eyeColor.Length != 3) return false;
            HashSet<string> colours = new HashSet<string>(7) {"amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (colours.Contains(eyeColor))
            {
                return true;
            }

            return false;
        }
}
