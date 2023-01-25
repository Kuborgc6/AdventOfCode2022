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

        int[] coorH = { 0, 0 };
        int[] coorT = { 0, 0 };
            
        foreach (String line in textInput)
        {
            switch (line[0])
            {
                case 'U':
                    coorH[0] += Convert.ToInt32(Char.GetNumericValue(line[2])); 
                    Console.WriteLine(coorH[0]);
                    break;
            }
        }
    }
}