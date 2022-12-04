Console.WriteLine("Day 3!");
//string textInput = File.ReadAllText("./inputfile.txt");
string textInput = File.ReadAllText(@"C:\Users\SiDzej\source\repos\AdventOfCode2022\AdventOfCode2022\inputfile.txt");
string[] rucksacks = textInput.Split('\n');

int allpriorities = 0;
foreach (string rucksack in rucksacks)
{
    string compartmentOne = rucksack.Substring(0, rucksack.Length / 2);
    string compartmentTwo = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);
    string isManyTimes = "";
    foreach (char item in compartmentOne)
    {
        int priority = 0;
        if ((compartmentTwo.Contains(item)) && !(isManyTimes.Contains(item)))
        {
            isManyTimes += item;
            if (Char.IsUpper(item))
                priority = item - 64 + 26;
            else
                priority = item - 96;
            allpriorities += priority;
        }
    }
}

Console.WriteLine("The sum of the priorities of items misplaced in rucksacks: " + allpriorities);