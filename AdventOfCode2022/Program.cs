Console.WriteLine("Day 5!");

string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
string sFilePath = Path.GetFullPath(sFile);
string textInput = @File.ReadAllText(sFilePath);

string[] devision = textInput.Split("\r\n\r\n");
Console.WriteLine(devision[0]);
//Console.WriteLine(devision[1]);
string[] containersLines = devision[0].Split("\n");
Console.WriteLine(containersLines[2][1+4]);

// number of containers = length/4
int containersNumber = containersLines[0].Length / 4;
Console.WriteLine(containersNumber);

string[] containers = new string[containersNumber];
foreach (string containerLine in containersLines)
{
    for (int i = 0; i < containersNumber; i++)
    {
        containers[i] += containerLine[1 + i * 4];
    }
}

for (int i = 0; i < containersNumber; i++)
{
    char[] charTemp = containers[i].ToCharArray();
    Array.Reverse(charTemp);
    containers[i] = new string(charTemp);
}

Console.WriteLine(containers[1]);
Console.WriteLine(containers[1].Length);