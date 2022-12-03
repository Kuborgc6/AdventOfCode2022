Console.WriteLine("Day 3!");
string textInput = System.IO.File.ReadAllText(@"C:\Users\SiDzej\source\repos\AdventOfCode2022\AdventOfCode2022\inputfile.txt");
char c = 'a';
int index = 0;
if (Char.IsUpper(c))
{
    index = char.ToUpper(c) - 64 + 26;
}
else
{
    index = char.ToUpper(c) - 64;
}
Console.WriteLine(index);