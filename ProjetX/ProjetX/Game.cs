using System.Drawing;
using static System.Console;



class Game
{
    static void Main()
    {
        Title = "Project-X";


        /*BackgroundColor = ConsoleColor.Red; //text
        ForegroundColor = ConsoleColor.Blue; */ //Surligne


        ConsoleKeyInfo key;
        string ligne;

        // Read the file as one string.
        StreamReader reader = new StreamReader("Map.txt");

        //string text = File.ReadAllText("Map.txt");
        string[,] grid = new string[27,95];
        ligne = reader.ReadLine();
        // Display the file contents to the console. Variable text is a string.
        for ( int x = 0; ligne != null; x++)  // Pour chaque ligne
        {
            string[] tab = ligne.Split("|"); // On récupère les 4 éléments dans un tableau

            for (int y = 0; y < 1; y++)
            {
                grid[x,y] = tab[y] ;
                string element = grid[x, y];
                // On remplit le tableau
                WriteLine(element); // On remplit le tableau
            }
            ligne = reader.ReadLine(); // On passe à la ligne suivante

        }
        SetCursorPosition(1,0);
       
        ReadKey();
        key = ReadKey(true);
        //WriteLine(key.Key);

        if (key.Key == ConsoleKey.LeftArrow)
        {
            WriteLine("Left");
            SetCursorPosition(0, 1);
            Write("O");
        }
        if (key.Key == ConsoleKey.DownArrow) { WriteLine("Down"); SetCursorPosition(0,+1); }
        if (key.Key == ConsoleKey.UpArrow) { WriteLine("Up"); SetCursorPosition(0, +1); }
        if (key.Key == ConsoleKey.RightArrow) { WriteLine("Right"); SetCursorPosition(0, +1); }
    }
}



