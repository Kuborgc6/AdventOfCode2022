Console.WriteLine("Day 4!");

string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
string sFilePath = Path.GetFullPath(sFile);
string textInput = @File.ReadAllText(sFilePath);

string[] workPair = textInput.Split('\n');
int howManyTimes = 0;
foreach (string workers in workPair)
{
    string[] assignments = workers.Split(',');
    if (Char.IsWhiteSpace(assignments[1], (assignments.Length - 1)))
        assignments[1] = assignments[1].Remove(assignments[1].Length - 1); //Removes whitespace character
    List<int> firstRange = assignments[0].Split('-').Select(int.Parse).ToList();
    List<int> secondRange = assignments[1].Split('-').Select(int.Parse).ToList();
    if (firstRange[0] <= secondRange[0] && firstRange[1] >= secondRange[1])
        howManyTimes++;
    else if (firstRange[0] >= secondRange[0] && firstRange[1] <= secondRange[1])
        howManyTimes++;
}

Console.WriteLine("Assignment pairs that one range fully contain the other: " + howManyTimes);

//-----
Console.WriteLine("Part Two!");

howManyTimes = 0;
foreach (string workers in workPair)
{
    string[] assignments = workers.Split(',');
    if (Char.IsWhiteSpace(assignments[1], (assignments.Length - 1)))
        assignments[1] = assignments[1].Remove(assignments[1].Length - 1); //Removes whitespace character
    List<int> firstRange = assignments[0].Split('-').Select(int.Parse).ToList();
    List<int> secondRange = assignments[1].Split('-').Select(int.Parse).ToList();
    if (firstRange[0] <= secondRange[0] && firstRange[1] >= secondRange[0])
        howManyTimes++;
    else if (firstRange[0] <= secondRange[1] && firstRange[1] >= secondRange[1])
        howManyTimes++;
    else if (firstRange[0] >= secondRange[0] && firstRange[0] <= secondRange[1])
        howManyTimes++;
    else if (firstRange[1] >= secondRange[0] && firstRange[1] <= secondRange[1])
        howManyTimes++;
}
Console.WriteLine("Assignment pairs that overlap: " + howManyTimes);
