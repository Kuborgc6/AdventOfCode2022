using System.IO;

public class folderDirectory
{
    public string currentFolder { get; set; } = "";
    public List<folderDirectory> subdirectories = new List<folderDirectory>();
    public int size = 0;
    public int correctSize = 0;

    public (int,int) calculateChildrenSize()
    {
        int result = 0;
        int howMany = 0;
        if (this.subdirectories.Count > 0) 
        {
            Console.WriteLine("Debug 0: " + result);
            foreach (folderDirectory tempFolder in this.subdirectories)
            {
                Console.WriteLine("Debug 1: " + tempFolder.currentFolder);
                (int resultTemp, int howManyTemp) = tempFolder.calculateChildrenSize();
                result += resultTemp;
                howMany += howManyTemp;
            }
            this.size += result;
            result = this.size;
        }
        else
        {
            result = this.size;
            Console.WriteLine("Debug 2: " + result);
        }
            
        if (this.size <= 100000)
            howMany += this.size;

        this.correctSize = howMany;

        return (result, howMany);
    }

    public bool Equals(folderDirectory other)
    {
        if (other == null) return false;
        return (this.currentFolder.Equals(other.currentFolder));
    }
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

        folderDirectory mainFolder = new folderDirectory();
        folderDirectory tempFolder = mainFolder;
        List<string> directory = new List<string>();

        foreach (string line in textInput)
        {
            string[] splitLine = line.Split(' ');
            if (line == "$ cd /")
            {
                mainFolder.currentFolder = splitLine[2];
                tempFolder = mainFolder;
                //Console.WriteLine(line);
            }
            else if (line == "$ cd ..")
            {
                directory.RemoveAt(directory.Count - 1);
                tempFolder = mainFolder;
                foreach (string oneDirectory in directory)
                {
                    tempFolder = tempFolder.subdirectories.Find(x => x.currentFolder == oneDirectory);
                }
                //Console.WriteLine(line);
            }
            else if (splitLine[0] == "$" && splitLine[1] == "cd" )
            {
                //Console.WriteLine(tempFolder.currentFolder);
                directory.Add(splitLine[2]);
                tempFolder = tempFolder.subdirectories.Find(x => x.currentFolder == splitLine[2]);
                //Console.WriteLine(tempFolder.currentFolder);

                //Console.WriteLine(line);
            }
            else if (line == "$ ls")
            {
                //Console.WriteLine(line);
            }
            else if (splitLine[0] != "dir" && splitLine[0] != "$")
            {
                tempFolder.size += int.Parse(splitLine[0]);
            }
            else if (splitLine[0] == "dir")
            {
                folderDirectory subfolder = new folderDirectory();
                subfolder.currentFolder = splitLine[1];
                tempFolder.subdirectories.Add(subfolder);
            }
        }
        Console.WriteLine("End line");

        (int resultSize, int resultFolders) = mainFolder.calculateChildrenSize();
        Console.WriteLine("Result Size: " + resultSize);
        Console.WriteLine("Result Folders: " + resultFolders);
        Console.WriteLine("Children: ");
        foreach (folderDirectory temp in mainFolder.subdirectories)
            Console.WriteLine(temp.currentFolder);
    }
}

