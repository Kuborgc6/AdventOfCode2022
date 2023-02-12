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
        {
            textInput[i] = textInput[i].Trim();
        }

        int[,] map = new int[textInput.Length, textInput[0].Length];
        int[] startCoord = {0, 0};
        int[] endCoord = { 0, 0 };

        for (int i = 0; i < textInput.Length; i++)
        {
            for(int j = 0; j < textInput[i].Length; j++)
            {
                if (textInput[i][j] == 'S')
                {
                    map[i, j] = 0;
                    startCoord[0] = i;
                    startCoord[1] = j;
                }
                else if (textInput[i][j] == 'E')
                {
                    map[i, j] = 27;
                    endCoord[0] = i;
                    endCoord[1] = j;
                }
                else
                    map[i, j] = textInput[i][j] - 96;
            }
        }
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]+"\t");
            }
            Console.Write("\n");
        }

        Console.WriteLine(startCoord[0] + " " + startCoord[1]);
        Console.WriteLine(endCoord[0] + " " + endCoord[1]);

    }
}