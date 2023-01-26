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
        int x = 1;
        int result = 0;
        foreach (string line in textInput)
        {
            string[] comands = line.Split(' ');
            if (comands[0] == "noop")
            {
                cycle++;
                if (((cycle - 20) % 40 == 0) && (cycle <= 220))
                    result += x * cycle;
            }
            else
            {
                cycle++;
                if (((cycle - 20) % 40 == 0) && (cycle <= 220))
                    result += x * cycle;
                cycle++;
                if (((cycle - 20) % 40 == 0) && (cycle <= 220))
                    result += x * cycle;
                x += int.Parse(comands[1]);
            }
        }

        Console.WriteLine("Sum of six signals: " + result);
    }
}