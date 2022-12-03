Console.WriteLine("Day 2");
string textInput = System.IO.File.ReadAllText(@"C:\Users\SiDzej\source\repos\AdventOfCode2022\AdventOfCode2022\inputfile.txt");
string[] games = textInput.Split('\n');
int score = 0;

foreach (var game in games)
{
    string[] players = game.Split(' ');
    players[1] = players[1].Remove(1);
    switch (players[1])
    {
        case "X": score += 1;
            break;
        case "Y": score += 2;
            break;
        case "Z": score += 3;
            break;
    }
    switch ((players[0], players[1]))
    {
        case ("A", "X"):
        case ("B", "Y"):
        case ("C", "Z"):
            score += 3;
            break;
        case ("A", "Y"):
        case ("B", "Z"):
        case ("C", "X"):
            score += 6;
            break;
    }
}
Console.WriteLine("Score without instructions: " + score);

//-------
score = 0;

foreach (var game in games)
{
    string[] players = game.Split(' ');
    players[1] = players[1].Remove(1);
    switch (players[1])
    {
        case "Y":
            score += 3;
            break;
        case "Z":
            score += 6;
            break;
    }
    switch ((players[0], players[1]))
    {
        case ("A", "X"):
        case ("B", "Z"):
        case ("C", "Y"):// 3 
            score += 3;
            break;
        case ("A", "Y"):
        case ("B", "X"):
        case ("C", "Z"):// 1
            score += 1;
            break;
        case ("A", "Z"):
        case ("B", "Y"):
        case ("C", "X"):
            score += 2; // 2
            break;
    }
}
Console.WriteLine("Score with instructions: " + score);