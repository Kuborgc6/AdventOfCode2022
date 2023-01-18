using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Xml.Linq;

public class TreeCount
{
    public int height = 0;
    public bool isSeen = false;
}



class Program
{
    public int visibleTrees(TreeCount[,] forest)
    {
        int result = 0;
        int rowsOrHeight = forest.GetLength(0);
        int colsOrWidth = forest.GetLength(1);

        //from up left corner from left to right
        for (int i = 0; i < rowsOrHeight; i++)
        {
            int highestTree = -1;
            for (int j = 0; j < colsOrWidth; j++)
            {
                if (forest[i,j].height > highestTree)
                {
                    highestTree = forest[i, j].height;
                    forest[i, j].isSeen = true;
                }
            }
        }

        //from up left corner from right to left
        for (int i = 0; i < rowsOrHeight; i++)
        {
            int highestTree = -1;
            for (int j = colsOrWidth - 1; j >= 0; j--)
            {
                if (forest[i,j].height > highestTree)
                {
                    highestTree = forest[i, j].height;
                    forest[i, j].isSeen = true;
                }
            }
        }

        //from up left corner from up to down
        for (int j = 0; j < colsOrWidth; j++)
        {
            int highestTree = -1;
            for (int i = 0; i < rowsOrHeight; i++)
            {
                if (forest[i, j].height > highestTree)
                {
                    highestTree = forest[i, j].height;
                    forest[i, j].isSeen = true;
                }
            }
        }

        //from up left corner from down to up
        for (int j = 0; j < colsOrWidth; j++)
        {
            int highestTree = -1;
            for (int i = rowsOrHeight - 1; i >= 0; i--)
            {
                if (forest[i, j].height > highestTree)
                {
                    highestTree = forest[i, j].height;
                    forest[i, j].isSeen = true;
                }
            }
        }

        //counting result
        for (int i = 0; i < rowsOrHeight; i++)
        {
            for (int j = 0; j < colsOrWidth; j++)
            {
                if (forest[i, j].isSeen == true)
                {
                    result++;
                }
            }
        }
        return result;
    }

    public int getScenicScore(TreeCount[,] forest)
    {
        int result = 0;
        int rowsOrHeight = forest.GetLength(0);
        int colsOrWidth = forest.GetLength(1);

        for (int i = 0; i < rowsOrHeight; i++)
        {
            for (int j = 0; j < colsOrWidth; j++)
            {

            }
        }


                return result;
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

        int[,] arrayInput = new int[textInput.Length, textInput.Length];
        int k = 0;
        int l = 0;
        foreach (string line in textInput)
        {
            l = 0;
            foreach (char c in line)
            {
                arrayInput[k, l] = int.Parse(new string(c, 1));
                l++;
            }
            k++;
        }


        TreeCount[,] forest = new TreeCount[textInput.Length, textInput.Length];
        for (int i = 0; i < textInput.Length; i++)
            for (int j = 0; j < textInput.Length; j++)
            { 
                TreeCount tempTree = new TreeCount();
                tempTree.height = arrayInput[i, j];
                forest[i, j] = tempTree;
            }

        var p = new Program();
        int result = p.visibleTrees(forest);
        Console.WriteLine("All visible trees: " + result);
    }
}