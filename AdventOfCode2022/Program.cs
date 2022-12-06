Console.WriteLine("Hello Advent of Code 2022!");

string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
string sFilePath = Path.GetFullPath(sFile);
string textInput = @File.ReadAllText(sFilePath);

string marker = "";
for (int i = 0; i < textInput.Length - 4; i++)
{
    marker = textInput.Substring(i, 4);
    if (marker.Distinct().Count() == marker.Length)
    { 
        Console.WriteLine("Marker is detected after " + (i + 4) + " characters processed");
        break;
    }
}

string message = "";
for (int i = 0; i < textInput.Length - 14; i++)
{
    message = textInput.Substring(i, 14);
    if (message.Distinct().Count() == message.Length)
    {
        Console.WriteLine("Message is detected after " + (i + 14) + " characters processed");
        break;
    }
}
