public class FolderDirectory
{
    public string currentFolder = "";
    public List<FolderDirectory> subdirectories = new List<FolderDirectory>();
    public List<string> files = new List<string>();
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

        FolderDirectory mainFolder = new FolderDirectory();

        foreach (string line in textInput)
        {
            string[] splitLine = line.Split(' ');
            if (splitLine[0] == "$" && splitLine[1] == "cd")
            {
                mainFolder.currentFolder = splitLine[2];
                Console.WriteLine(line);
            }
        }       
    }
}

