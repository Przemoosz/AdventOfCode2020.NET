using System.Buffers;

namespace AdventOfCode2020;

public static class Day4Challange1
{
    public static async Task Run()
    {
        PassportSolution passportSolution = new PassportSolution();
        await passportSolution.Start();
        Console.WriteLine(passportSolution.ValidationStatus);
    }
}

internal class PassportSolution
{
    private int _validPassports=0;
    public int ValidationStatus
    {
        get => _validPassports;
    }
    public PassportSolution()
    {
        // FileRead();
    }

    public async Task Start()
    {
        await FileRead();
    }
    private async Task FileRead()
    {
        string path = Directory.GetCurrentDirectory() + "\\input.txt";
        // Console.WriteLine(path);
        
        
        using (FileStream stream = File.OpenRead(path))
        {
            using (StreamReader streamReader = new StreamReader(stream))
            {
                HashSet<string> set = new HashSet<string>();
                while (!streamReader.EndOfStream)
                {
                    // ReadOnlySpan<char> kvpAsSpan = 
                    string line = await streamReader.ReadLineAsync();
                    // Console.WriteLine(line);
                    if (line.Equals(""))
                    {
                        // Console.WriteLine("====");
                        if (Validation(ref set))
                        {
                            _validPassports += 1;
                        }
                        continue;
                    }
                    
                    List<string> splitedElements = line.Split(" ").ToList();
                    foreach (var i in splitedElements)
                    {
                        set.Add(i.Split(":")[0]);
                        // Console.WriteLine(i.Split(":")[0]);
                    }
                }
                if (Validation(ref set))
                {
                    _validPassports += 1;
                }
                // Console.WriteLine(await streamReader.ReadToEndAsync());
            }
        }
        
        
    }

    private bool Validation(ref HashSet<string> set)
    {
        if (set.Count == 8)
        {
            set.Clear();
            return true;
        }
        else if (set.Count == 7 && !set.Contains("cid"))
        {
            set.Clear();
            return true;
        }
        set.Clear();
        return false;
    }
}