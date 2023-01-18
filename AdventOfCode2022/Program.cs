class TreeCount
{
    public int height = 0;
    public bool isSeen = false;

}

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

        foreach (string line in textInput)
            Console.WriteLine(line);

        TreeCount[,] forest = new TreeCount[textInput.Length, textInput.Length];
        for (int i = 0; i < textInput.Length; i++)
            for (int j = 0; j < textInput.Length; j++)
                TreeCount tempTree = new TreeCount();
                
                forest[i,j] = 

    }
}