﻿class Monkey
{
    public int ID;
    public List<long> startingItems = new List<long>();
    public long operation;
    public bool isOld = false;
    public long test;
    public int trueMonkey;
    public int falseMonkey;
    public char functionMonkey;
    public long howMany = 0;

    public List<Monkey> chooseMonkeyList(List<Monkey> monkeyList, long quotient)
    {
        foreach (long item in this.startingItems)
        {
            int chooseMonkey = -1;
            long worrylevel = 0;
            if ((this.functionMonkey == '+') && (isOld == false))
                worrylevel = item + this.operation;
            else if ((this.functionMonkey == '*') && (isOld == false))
                worrylevel = item * this.operation;
            else
                worrylevel = item * item;

            if ((long)(worrylevel / quotient) > 1)
                worrylevel -= quotient * ((long)(worrylevel / quotient) - 1);
                

            //int itemAfter = (int)((worrylevel / 3));
            long itemAfter = worrylevel;
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

        int numberRounds = 10000;
        List<Monkey> monkeys = new List<Monkey>();
        List<long> mostActive = new List<long>() {0,0};
        long wholeQuotient = 1;

        for (int i = 0; i < (textInput.Count() + 1) / 7; i++)
        {
            Monkey monkey = new Monkey();
            monkey.ID = Convert.ToInt32(Char.GetNumericValue(textInput[i * 7].Split(' ')[1][0]));
            foreach (string item in textInput[i * 7 + 1].Split(':')[1].Trim().Split(", "))
                monkey.startingItems.Add(Convert.ToInt64(item));

            monkey.functionMonkey = textInput[i * 7 + 2].Split("old")[1].Trim()[0];
            if (textInput[i * 7 + 2].Split("old")[1].Trim().Count() == 1)
                monkey.isOld = true;
            else
                monkey.operation = Convert.ToInt64(textInput[i * 7 + 2].Split("old")[1].Trim().Split(' ')[1].ToString());

            monkey.test = Convert.ToInt64(textInput[i * 7 + 3].Split("by")[1].Trim());
            wholeQuotient *= monkey.test;
            monkey.trueMonkey = int.Parse(textInput[i * 7 + 4].Split("monkey")[1].Trim());
            monkey.falseMonkey = int.Parse(textInput[i * 7 + 5].Split("monkey")[1].Trim());

            monkeys.Add(monkey);
        }

        for (int i = 0; i < numberRounds; i++)
        {
            foreach (var monkey in monkeys)
                monkeys = monkey.chooseMonkeyList(monkeys, wholeQuotient);
        }

        foreach (var monkey in monkeys)
        {
            Console.WriteLine("ID: " + monkey.ID);
            Console.WriteLine("Items:");
            foreach (var item in monkey.startingItems)
                Console.WriteLine(item);
            Console.WriteLine("Monkey " + monkey.ID + " inspected items " + monkey.howMany + " times.");
            if (mostActive.Min() < monkey.howMany)
                mostActive[mostActive.IndexOf(mostActive.Min())] = monkey.howMany;
        }
        Console.WriteLine("The level of monkey business: " + (mostActive[0] * mostActive[1]));
    }
}