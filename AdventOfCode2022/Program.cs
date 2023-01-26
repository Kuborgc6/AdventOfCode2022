class Monkey
{
    int ID;
    List<int> startingItems;
    int operation;
    int test;
    int trueMonkey;
    int falseMonkey;
    char functionMonkey;
    int howMany = 0;

    List<Monkey> chooseMonkeyList(List<Monkey> monkeyList)
    {
        foreach (int item in this.startingItems)
        {
            int chooseMonkey = -1;
            int worrylevel = 0;
            if (this.functionMonkey == '+')
                worrylevel = item + this.operation;
            else if (this.functionMonkey == '*')
                worrylevel = item * this.operation;

            int itemAfter = decimal.ToInt32(Math.Round(Convert.ToDecimal(worrylevel) / 3));
            if (itemAfter % test == 0)
                chooseMonkey = this.trueMonkey;
            else
                chooseMonkey = this.falseMonkey;
            foreach (Monkey monkey in monkeyList)
            {
                if (monkey.ID == chooseMonkey)
                    monkey.startingItems.Add(itemAfter);
            }
            howMany++;
        }
        this.startingItems.Clear();
        return monkeyList;
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
        
        for (int i = 0; i < (textInput.Count()+1)/7; i++)
        {
            int IDMonkey = Convert.ToInt32(Char.GetNumericValue(textInput[i*7].Split(' ')[1][0]));
            Console.WriteLine(textInput[i * 7 + 1].Split(':')[1].Trim().Split(", ")[0]);
            Console.WriteLine(textInput[i * 7 + 2].Split("old")[1].Trim());
        }
        


    }
}