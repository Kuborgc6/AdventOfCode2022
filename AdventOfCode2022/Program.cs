// See https://aka.ms/new-console-template for more information
Console.WriteLine("Day 4!");

string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
string sFilePath = Path.GetFullPath(sFile);

string textInput = @File.ReadAllText(sFilePath);
