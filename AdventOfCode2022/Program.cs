class Monkey
{
    public int ID;
    public List<int> startingItems = new List<int>();
    public int operation;
    public bool isOld = false;
    public int test;
    public int trueMonkey;
    public int falseMonkey;
    public char functionMonkey;
    public int howMany = 0;

    List<Monkey> chooseMonkeyList(List<Monkey> monkeyList)
    {
        foreach (int item in this.startingItems)
        {
            int chooseMonkey = -1;
            int worrylevel = 0;
            if ((this.functionMonkey == '+') && (isOld == false))
                worrylevel = item + this.operation;
            else if ((this.functionMonkey == '*') && (isOld == false))
                worrylevel = item * this.operation;
            else
                worrylevel = item * item;

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

        List<Monkey> monkeys = new List<Monkey>();

        for (int i = 0; i < (textInput.Count() + 1) / 7; i++)
        {
            Monkey monkey = new Monkey();
            monkey.ID = Convert.ToInt32(Char.GetNumericValue(textInput[i * 7].Split(' ')[1][0]));
            foreach (string item in textInput[i * 7 + 1].Split(':')[1].Trim().Split(", "))
                monkey.startingItems.Add(Convert.ToInt32(item));

            monkey.functionMonkey = textInput[i * 7 + 2].Split("old")[1].Trim()[0];
            if (textInput[i * 7 + 2].Split("old")[1].Trim().Count() == 1)
                monkey.isOld = true;
            else
                monkey.operation = int.Parse(textInput[i * 7 + 2].Split("old")[1].Trim().Split(' ')[1].ToString());

            monkey.test = int.Parse(textInput[i * 7 + 3].Split("by")[1].Trim());
            monkey.trueMonkey = int.Parse(textInput[i * 7 + 4].Split("monkey")[1].Trim());
            monkey.falseMonkey = int.Parse(textInput[i * 7 + 5].Split("monkey")[1].Trim());

            monkeys.Add(monkey);
        }
        foreach(var monkey in monkeys)
        {
            Console.WriteLine("ID: " + monkey.ID);
            Console.WriteLine("Function: " + monkey.functionMonkey);
            Console.WriteLine("Items:");
            foreach (var item in monkey.startingItems)
                Console.WriteLine(item);
        }

    }
}