using System.Drawing;

class Program
{
    List<List<int>> DistinctList(List<List<int>> coorSave)
    {
        List<List<int>> result = new List<List<int>>();
        foreach (var coor in coorSave)
        {
            if (result.Count == 0)
                result.Add(coor);
            else
            {
                bool check = false;
                foreach (var item in result)
                {
                    if ((item[0] == coor[0]) && (item[1] == coor[1]))
                        check = true;
                }
                if (check == false)
                    result.Add(coor);
            }
        }
        return result;
    }
    
    List<int> Check(List<int> coorH, List<int> coorT)
    {
        if ((Math.Abs(coorH[0] - coorT[0]) >= 1) && (Math.Abs(coorH[1] - coorT[1]) > 1) ||
            (Math.Abs(coorH[0] - coorT[0]) > 1) && (Math.Abs(coorH[1] - coorT[1]) >= 1))
        {
            if (coorH[0] - coorT[0] > 0)
                coorT[0]++;
            else
                coorT[0]--;
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }
        else if ((Math.Abs(coorH[0] - coorT[0]) > 1))
        {
            if (coorH[0] - coorT[0] > 0)
                coorT[0]++;
            else
                coorT[0]--;
        }
        else if ((Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }
        return coorT;
    }

    List<int> CheckDown(List<int> coorH, List<int> coorT)
    {
        if ((Math.Abs(coorH[0] - coorT[0]) >= 1) && (Math.Abs(coorH[1] - coorT[1]) > 1) ||
            (Math.Abs(coorH[0] - coorT[0]) > 1) && (Math.Abs(coorH[1] - coorT[1]) >= 1))
        {
            if (coorH[0] - coorT[0] > 0)
                coorT[0]++;
            else
                coorT[0]--;
            coorT[1]--;
        }
        else if ((Math.Abs(coorH[0] - coorT[0]) > 1))
        {
            if (coorH[0] - coorT[0] > 0)
                coorT[0]++;
            else
                coorT[0]--;
        }
        else if ((Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }

        return coorT;
    }

    List<int> CheckRight(List<int> coorH, List<int> coorT)
    {
        if ((Math.Abs(coorH[0] - coorT[0]) >= 1) && (Math.Abs(coorH[1] - coorT[1]) > 1) ||
            (Math.Abs(coorH[0] - coorT[0]) > 1) && (Math.Abs(coorH[1] - coorT[1]) >= 1))
        {
            coorT[0]++;
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }
        else if ((Math.Abs(coorH[0] - coorT[0]) > 1))
        {
            coorT[0]++;
        }
        else if ((Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }
        return coorT;
    }

    List<int> CheckLeft(List<int> coorH, List<int> coorT)
    {
        if ((Math.Abs(coorH[0] - coorT[0]) >= 1) && (Math.Abs(coorH[1] - coorT[1]) > 1) ||
            (Math.Abs(coorH[0] - coorT[0]) > 1) && (Math.Abs(coorH[1] - coorT[1]) >= 1))
        {
            coorT[0]--;
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }
        else if ((Math.Abs(coorH[0] - coorT[0]) > 1))
        {
            coorT[0]--;
        }
        else if ((Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }
        return coorT;
    }
    static void Main()
    {
        Console.WriteLine("Hello Advent of Code 2022!");

        string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
        string sFilePath = Path.GetFullPath(sFile);
        string[] textInput = @File.ReadAllLines(sFilePath);

        for (int i = 0; i < textInput.Length; i++)
            textInput[i] = textInput[i].Trim();

        List<int> coorH = new List<int> { 0, 0 };
        List<int> coorT1 = new List<int> { 0, 0 };
        List<int> coorT2 = new List<int> { 0, 0 };
        List<int> coorT3 = new List<int> { 0, 0 };
        List<int> coorT4 = new List<int> { 0, 0 };
        List<int> coorT5 = new List<int> { 0, 0 };
        List<int> coorT6 = new List<int> { 0, 0 };
        List<int> coorT7 = new List<int> { 0, 0 };
        List<int> coorT8 = new List<int> { 0, 0 };
        List<int> coorT9 = new List<int> { 0, 0 };

        List<List<int>> coorSave1 = new List<List<int>>();
        List<List<int>> coorSave9 = new List<List<int>>();
        List<int> CoorTtemp= new List<int>(coorT1);
        coorSave1.Add(CoorTtemp);
        coorSave9.Add(CoorTtemp);
        Program p = new Program();

        foreach (String line in textInput)
        {
            string[] words = line.Split(' ');
            int distance = int.Parse(words[1]);
            switch (line[0])
            {
                case 'U':
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[1]++;
                        coorT1 = p.Check(coorH, coorT1);
                        coorT2 = p.Check(coorT1, coorT2);
                        coorT3 = p.Check(coorT2, coorT3);
                        coorT4 = p.Check(coorT3, coorT4);
                        coorT5 = p.Check(coorT4, coorT5);
                        coorT6 = p.Check(coorT5, coorT6);
                        coorT7 = p.Check(coorT6, coorT7);
                        coorT8 = p.Check(coorT7, coorT8);
                        coorT9 = p.Check(coorT8, coorT9);

                        List<int> copyCoorT1 = new List<int>(coorT1);
                        List<int> copyCoorT9 = new List<int>(coorT9);
                        coorSave1.Add(copyCoorT1);
                        coorSave9.Add(copyCoorT9);
                    }
                    break;

                case 'D':
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[1]--;
                        coorT1 = p.Check(coorH, coorT1);
                        coorT2 = p.Check(coorT1, coorT2);
                        coorT3 = p.Check(coorT2, coorT3);
                        coorT4 = p.Check(coorT3, coorT4);
                        coorT5 = p.Check(coorT4, coorT5);
                        coorT6 = p.Check(coorT5, coorT6);
                        coorT7 = p.Check(coorT6, coorT7);
                        coorT8 = p.Check(coorT7, coorT8);
                        coorT9 = p.Check(coorT8, coorT9);

                        List<int> copyCoorT1 = new List<int>(coorT1);
                        List<int> copyCoorT9 = new List<int>(coorT9);
                        coorSave1.Add(copyCoorT1);
                        coorSave9.Add(copyCoorT9);
                    }
                    break;
                case 'R':
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[0]++;
                        coorT1 = p.Check(coorH, coorT1);
                        coorT2 = p.Check(coorT1, coorT2);
                        coorT3 = p.Check(coorT2, coorT3);
                        coorT4 = p.Check(coorT3, coorT4);
                        coorT5 = p.Check(coorT4, coorT5);
                        coorT6 = p.Check(coorT5, coorT6);
                        coorT7 = p.Check(coorT6, coorT7);
                        coorT8 = p.Check(coorT7, coorT8);
                        coorT9 = p.Check(coorT8, coorT9);

                        List<int> copyCoorT1 = new List<int>(coorT1);
                        List<int> copyCoorT9 = new List<int>(coorT9);
                        coorSave1.Add(copyCoorT1);
                        coorSave9.Add(copyCoorT9);
                    }
                    break;
                case 'L':
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[0]--;
                        coorT1 = p.Check(coorH, coorT1);
                        coorT2 = p.Check(coorT1, coorT2);
                        coorT3 = p.Check(coorT2, coorT3);
                        coorT4 = p.Check(coorT3, coorT4);
                        coorT5 = p.Check(coorT4, coorT5);
                        coorT6 = p.Check(coorT5, coorT6);
                        coorT7 = p.Check(coorT6, coorT7);
                        coorT8 = p.Check(coorT7, coorT8);
                        coorT9 = p.Check(coorT8, coorT9);

                        List<int> copyCoorT1 = new List<int>(coorT1);
                        List<int> copyCoorT9 = new List<int>(coorT9);
                        coorSave1.Add(copyCoorT1);
                        coorSave9.Add(copyCoorT9);
                    }
                    break;
            }
        }

        List<List<int>> distinctList1 = p.DistinctList(coorSave1);
        List<List<int>> distinctList9 = p.DistinctList(coorSave9);
        Console.WriteLine("\nDistinct list");

        Console.WriteLine("Number of positions of 1: " + distinctList1.Count);
        Console.WriteLine("Number of positions of 9: " + distinctList9.Count);
    }
}