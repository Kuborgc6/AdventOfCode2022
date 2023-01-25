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
    
    List<int> CheckUp(List<int> coorH, List<int> coorT)
    {
        if ((Math.Abs(coorH[0] - coorT[0]) == 1) && (Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            if (coorH[0] - coorT[0] > 0)
                coorT[0]++;
            else
                coorT[0]--;
            coorT[1]++;
        }
        else if ((Math.Abs(coorH[0] - coorT[0]) > 1) || (Math.Abs(coorH[1] - coorT[1]) > 1))
            coorT[1]++;
        return coorT;
    }

    List<int> CheckDown(List<int> coorH, List<int> coorT)
    {
        if ((Math.Abs(coorH[0] - coorT[0]) == 1) && (Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            if (coorH[0] - coorT[0] > 0)
                coorT[0]++;
            else
                coorT[0]--;
            coorT[1]--;
        }
        else if ((Math.Abs(coorH[0] - coorT[0]) > 1) || (Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            coorT[1]--;
        }
        return coorT;
    }

    List<int> CheckRight(List<int> coorH, List<int> coorT)
    {
        if ((Math.Abs(coorH[0] - coorT[0]) > 1) && (Math.Abs(coorH[1] - coorT[1]) == 1))
        {
            coorT[0]++;
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }
        else if ((Math.Abs(coorH[0] - coorT[0]) > 1) || (Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            coorT[0]++;
        }
        return coorT;
    }

    List<int> CheckLeft(List<int> coorH, List<int> coorT)
    {
        if ((Math.Abs(coorH[0] - coorT[0]) > 1) && (Math.Abs(coorH[1] - coorT[1]) == 1))
        {
            coorT[0]--;
            if (coorH[1] - coorT[1] > 0)
                coorT[1]++;
            else
                coorT[1]--;
        }
        else if ((Math.Abs(coorH[0] - coorT[0]) > 1) || (Math.Abs(coorH[1] - coorT[1]) > 1))
        {
            coorT[0]--;
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
        List<int> coorT = new List<int> { 0, 0 };
        List<List<int>> coorSave = new List<List<int>>();
        List<int> CoorTtemp= new List<int>(coorT);
        coorSave.Add(CoorTtemp);
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
                        coorT = p.CheckUp(coorH, coorT);
                        List<int> copyCoorT = new List<int>(coorT);
                        coorSave.Add(copyCoorT);
                    }
                    break;

                case 'D':
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[1]--;
                        coorT = p.CheckDown(coorH, coorT);
                        List<int> copyCoorT = new List<int>(coorT);
                        coorSave.Add(copyCoorT);
                    }
                    break;
                case 'R':
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[0]++;
                        coorT = p.CheckRight(coorH, coorT);
                        List<int> copyCoorT = new List<int>(coorT);
                        coorSave.Add(copyCoorT);
                    }
                    break;
                case 'L':
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[0]--;
                        coorT = p.CheckLeft(coorH, coorT);
                        List<int> copyCoorT = new List<int>(coorT);
                        coorSave.Add(copyCoorT);
                    }
                    break;
            }
        }

        List<List<int>> distinctList = p.DistinctList(coorSave);
        Console.WriteLine("\nDistinct list");

        Console.WriteLine("Number of positions: " + distinctList.Count);
    }
}