using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello Advent of Code 2022!");

        string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
        string sFilePath = Path.GetFullPath(sFile);
        string[] textInput = @File.ReadAllLines(sFilePath);

        for (int i = 0; i < textInput.Length; i++)
            textInput[i] = textInput[i].Trim();
        int cycle = 0;
        int cycleWrite = 0;
        int x = 1;
        int result = 0;
        List<int> sprite = new List<int> {1, 2 ,3};

        var empty_character = "░░";
        var filled_character = "██";
        string writtenText = "";

        foreach (string line in textInput)
        {
            string[] comands = line.Split(' ');
            if (comands[0] == "noop")
            {
                cycle++;
                if (((cycle - 20) % 40 == 0) && (cycle <= 220))
                    result += x * cycle;

                cycleWrite++;
                if (cycleWrite > 40)
                    cycleWrite -= 40;

                if (sprite.Contains(cycleWrite))
                    writtenText += filled_character;
                else
                    writtenText += empty_character;
            }
            else
            {
                //First cycle
                cycle++;
                if (((cycle - 20) % 40 == 0) && (cycle <= 220))
                    result += x * cycle;
                
                cycleWrite++;
                if (cycleWrite > 40)
                    cycleWrite -= 40;

                if (sprite.Contains(cycleWrite))
                    writtenText += filled_character;
                else
                    writtenText += empty_character;
                
                //Second cycle
                cycle++;
                if (((cycle - 20) % 40 == 0) && (cycle <= 220))
                    result += x * cycle;

                cycleWrite++;
                if (cycleWrite > 40)
                    cycleWrite -= 40;

                if (sprite.Contains(cycleWrite))
                    writtenText += filled_character;
                else
                    writtenText += empty_character;

                x += int.Parse(comands[1]);
                sprite[0] += int.Parse(comands[1]);
                sprite[1] += int.Parse(comands[1]);
                sprite[2] += int.Parse(comands[1]);
            }
        }
        for (int i = 0; i < (writtenText.Count() / 80); i++)
            Console.WriteLine(writtenText.Substring(i * 80,80));

        Console.WriteLine("Sum of six signals: " + result);
    }
}