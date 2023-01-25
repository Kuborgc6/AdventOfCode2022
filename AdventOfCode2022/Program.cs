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

        List<int> coorH = new List<int> { 0, 0 };
        List<int> coorT = new List<int> { 0, 0 };
        List<List<int>> coorSave = new List<List<int>>();
        List<int> CoorTtemp= new List<int>(coorT);
        coorSave.Add(CoorTtemp);

        foreach (String line in textInput)
        {
            string[] words = line.Split(' ');
            int distance = 0;
            switch (line[0])
            {
                case 'U':
                    distance = int.Parse(words[1]);
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[1]++;
                        if ((Math.Abs(coorH[0] - coorT[0]) == 1) && (Math.Abs(coorH[1] - coorT[1]) > 1))
                        { 
                            if (coorH[0] - coorT[0] > 0)
                                coorT[0]++;
                            else
                                coorT[0]--;
                            coorT[1]++;

                            if (!coorSave.Contains(coorT))
                            {
                                List<int> copyCoorT = new List<int>(coorT);
                                coorSave.Add(copyCoorT);
                            }
                        }
                        else if ((Math.Abs(coorH[0] - coorT[0]) > 1) || (Math.Abs(coorH[1] - coorT[1]) > 1))
                        { 
                            coorT[1]++;
                            if (!coorSave.Contains(coorT))
                            {
                                List<int> copyCoorT = new List<int>(coorT);
                                coorSave.Add(copyCoorT);
                            }
                        }
                    }
                    break;

                case 'D':
                    distance = int.Parse(words[1]);
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[1]--;
                        if ((Math.Abs(coorH[0] - coorT[0]) == 1) && (Math.Abs(coorH[1] - coorT[1]) > 1))
                        {
                            if (coorH[0] - coorT[0] > 0)
                                coorT[0]++;
                            else
                                coorT[0]--;
                            coorT[1]--;
                            if (!coorSave.Contains(coorT))
                            {
                                List<int> copyCoorT = new List<int>(coorT);
                                coorSave.Add(copyCoorT);
                            }
                        }
                        else if ((Math.Abs(coorH[0] - coorT[0]) > 1) || (Math.Abs(coorH[1] - coorT[1]) > 1))
                        {
                            coorT[1]--;
                            if (!coorSave.Contains(coorT))
                            {
                                List<int> copyCoorT = new List<int>(coorT);
                                coorSave.Add(copyCoorT);
                            }
                        }
                    }
                    break;
                case 'R':
                    distance = int.Parse(words[1]);
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[0]++;
                        if ((Math.Abs(coorH[0] - coorT[0]) > 1) && (Math.Abs(coorH[1] - coorT[1]) == 1))
                        {
                            coorT[0]++;
                            if (coorH[1] - coorT[1] > 0)
                                coorT[1]++;
                            else
                                coorT[1]--;
                            if (!coorSave.Contains(coorT))
                            {
                                List<int> copyCoorT = new List<int>(coorT);
                                coorSave.Add(copyCoorT);
                            }
                        }
                        else if ((Math.Abs(coorH[0] - coorT[0]) > 1) || (Math.Abs(coorH[1] - coorT[1]) > 1))
                        {
                            coorT[0]++;
                            if (!coorSave.Contains(coorT))
                            {
                                List<int> copyCoorT = new List<int>(coorT);
                                coorSave.Add(copyCoorT);
                            }
                        }
                    }
                    break;
                case 'L':
                    distance = int.Parse(words[1]);
                    for (int j = 0; j < distance; j++)
                    {
                        coorH[0]--;
                        if ((Math.Abs(coorH[0] - coorT[0]) > 1) && (Math.Abs(coorH[1] - coorT[1]) == 1))
                        {
                            coorT[0]--;
                            if (coorH[1] - coorT[1] > 0)
                                coorT[1]++;
                            else
                                coorT[1]--;
                            if (!coorSave.Contains(coorT))
                            {
                                List<int> copyCoorT = new List<int>(coorT);
                                coorSave.Add(copyCoorT);
                            }
                        }
                        else if((Math.Abs(coorH[0] - coorT[0]) > 1) || (Math.Abs(coorH[1] - coorT[1]) > 1))
                        {
                            coorT[0]--;
                            if (!coorSave.Contains(coorT))
                            {
                                List<int> copyCoorT = new List<int>(coorT);
                                coorSave.Add(copyCoorT);
                            }
                        }
                    }
                    break;
            }
        }
        foreach (List<int> coorTemp in coorSave)
        {
            Console.WriteLine("x: " + coorTemp[0] + "\ty: " + coorTemp[1]);
        }
        List<List<int>> distinctList = coorSave.Distinct().ToList();
        Console.WriteLine("\nDistinct list");
        foreach (List<int> coorTemp in distinctList)
        {
            Console.WriteLine("x: " + coorTemp[0] + "\ty: " + coorTemp[1]);
        }
        Console.WriteLine("Number of positions: "+coorSave.Count);
    }
}