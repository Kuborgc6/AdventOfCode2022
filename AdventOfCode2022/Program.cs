Console.WriteLine("Day 3!");
//string textInput = File.ReadAllText("./inputfile.txt");
string textInput = File.ReadAllText(@"C:\Users\SiDzej\source\repos\AdventOfCode2022\AdventOfCode2022\inputfile.txt");
string[] rucksacks = textInput.Split('\n');

int allprioritiesPartOne = 0;
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
            allprioritiesPartOne += priority;
        }
    }
}

Console.WriteLine("The sum of the priorities of items misplaced in rucksacks: " + allprioritiesPartOne);


//---------------
Console.WriteLine("Part Two of Day 3!");
int allprioritiesPartTwo = 0;


for (int i = 0; i < rucksacks.Count()-2; i = i + 3)
{
    string rucksack1 = rucksacks[i];
    string rucksack2 = rucksacks[i + 1];
    string rucksack3 = rucksacks[i + 2];
    string isManyTimes = "";
    rucksack1 = rucksack1.Remove(rucksack1.Length - 1); //Removes whitespace character 
    foreach (char item in rucksack1)
    {
        int priority = 0;
        if (rucksack2.Contains(item) && rucksack3.Contains(item) && !(isManyTimes.Contains(item)))
        {
            isManyTimes += item;
            if (Char.IsUpper(item))
                priority = item - 64 + 26;
            else
                priority = item - 96;
            allprioritiesPartTwo += priority;
        }
    }
}

Console.WriteLine("The sum of the priorities of badges of rucksacks: " + allprioritiesPartTwo);
