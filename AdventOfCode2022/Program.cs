using System.Text.RegularExpressions;

Console.WriteLine("Day 5!");

string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
string sFilePath = Path.GetFullPath(sFile);
string textInput = @File.ReadAllText(sFilePath);

string[] devision = textInput.Split("\r\n\r\n");
Console.WriteLine(devision[0]);
string[] containersLines = devision[0].Split("\n");

// number of containers = length/4
int containersNumber = containersLines[0].Length / 4;

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

for (int i = 0; i < containersNumber; i++)
    while (Char.IsWhiteSpace(containers[i], (containers[i].Length - 1)))
        containers[i] = containers[i].Remove(containers[i].Length - 1);

for (int i = 0; i < containersNumber; i++)
{
    Console.WriteLine("Container: " + (i + 1));
    Console.WriteLine(containers[i]);
    Console.WriteLine(containers[i].Length-1);
}

Console.WriteLine();
Console.WriteLine("Taking care of procedure");
Console.WriteLine();

Console.WriteLine(devision[1]);

string[] procdureLines = devision[1].Split("\n");
string[] ordersNumbers = new string[procdureLines.Length];
for (int i = 0; i < procdureLines.Length; i++)
{
    ordersNumbers[i] = string.Concat(procdureLines[i].Where(Char.IsDigit));
}
Console.WriteLine(ordersNumbers[1]);
