Console.WriteLine("Day 3!");
string textInput = System.IO.File.ReadAllText(@"C:\Users\SiDzej\source\repos\AdventOfCode2022\AdventOfCode2022\inputfile.txt");
char c = 'a';
string[] rucksacks = textInput.Split('\n');

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

foreach (string rucksack in rucksacks)
{
    string compartmentOne = rucksack.Substring(0, rucksack.Length / 2);
    string compartmentTwo = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);
    Console.WriteLine(rucksack);
    Console.WriteLine(compartmentOne);
    Console.WriteLine(compartmentTwo);
    break;

}