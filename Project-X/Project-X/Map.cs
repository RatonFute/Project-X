using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using static System.Console;


class Map
{
    public static void Main()
    {
        /*BackgroundColor = ConsoleColor.Red; //text
        ForegroundColor = ConsoleColor.Blue; */ //Surline


        ConsoleKeyInfo key;
        string line;

        // Read the file as one string.
        StreamReader reader = new StreamReader("Map.txt");

        string[,] grid = new string[27,95];
        line = reader.ReadLine();
        string element;
        // Display the file contents to the console. Variable text is a string.
        while (line!=null)
        {
            for (int x = 0; line != null; x++)  // Pour chaque line
            {
                string[] tab = line.Split("|"); // On récupère les éléments dans un tableau

                for ( int y = 0; y < 1; y++)
                {
                    grid[x, y] = tab[y];
                    element = grid[x, y];
                    WriteLine(element); // On remplit le tableau
                    element.Contains("*");
                }
                line = reader.ReadLine(); // On passe à la line suivante

            }
            //Write(grid[0, 5]);

        }


        SetCursorPosition(1,1);
        Write("0");
        ReadKey();
        key = ReadKey(true);
        //WriteLine(key.Key);

        if (key.Key == ConsoleKey.LeftArrow){WriteLine("Left"); SetCursorPosition(-1, 0);  Write("O");}
        if (key.Key == ConsoleKey.DownArrow) { WriteLine("Down"); SetCursorPosition(0,-1); }
        if (key.Key == ConsoleKey.UpArrow) { WriteLine("Up"); SetCursorPosition(0, +1); }
        if (key.Key == ConsoleKey.RightArrow) { WriteLine("Right"); SetCursorPosition(+1, 0); }
    }
}