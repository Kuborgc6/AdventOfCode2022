﻿using System.ComponentModel;
using System.Text.RegularExpressions;

Console.WriteLine("Day 5!");

string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
string sFilePath = Path.GetFullPath(sFile);
string textInput = @File.ReadAllText(sFilePath);

string[] devision = textInput.Split("\r\n\r\n");
string[] containersLines = devision[0].Split("\n");

// number of containers = length/4
int containersNumber = containersLines[0].Length / 4;

string[] containers = new string[containersNumber];
foreach (string containerLine in containersLines)
{
    for (int i = 0; i < containersNumber; i++)
    {
        containers[i] += containerLine[1 + i * 4];
    }
}

for (int i = 0; i < containersNumber; i++)
{
    char[] charTemp = containers[i].ToCharArray();
    Array.Reverse(charTemp);
    containers[i] = new string(charTemp);
    containers[i] = containers[i].Trim(); // Using Trim()
}



string[] procdureLines = devision[1].Split("\n");
string[] ordersNumbers = new string[procdureLines.Length];
for (int i = 0; i < procdureLines.Length; i++)
{
    ordersNumbers[i] = string.Concat(procdureLines[i].Where(Char.IsDigit));
}

foreach (string orders in ordersNumbers)
{
    string tempOrders = orders;
    int finalCon = int.Parse(tempOrders[tempOrders.Length - 1].ToString());
    tempOrders = tempOrders.Remove(tempOrders.Length - 1);

    int originCon = int.Parse(tempOrders[tempOrders.Length - 1].ToString());
    tempOrders = tempOrders.Remove(tempOrders.Length - 1);

    int howMany = int.Parse(tempOrders.ToString());
    for (int i = 0; i < howMany; i++)
    {
        char item = containers[originCon - 1][containers[originCon - 1].Length - 1];
        containers[originCon - 1] = containers[originCon - 1].Remove(containers[originCon - 1].Length - 1);
        containers[finalCon - 1] += item;
    }
}

string result = "";
foreach (string container in containers)
{
    result += container[container.Length - 1];
}

Console.WriteLine("Crates that end up on top of each stack are: " + result);