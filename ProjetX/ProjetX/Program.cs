// See https://aka.ms/new-console-template for more information
using ProjetX;
using System.Runtime.CompilerServices;
using static System.Console;
WriteLine("Hello, World!");
ConsoleKeyInfo key;
string[] playerClass = new string[] { "warrior", "knight", "wizard" };
string[] ennemyClass = new string[] { "ennemy", "cheval" };
bool isRunning = true;
bool isFighting = false;
WriteLine("----------------------------------");
Player player = new Player();
Ennemy ennemy = new Ennemy();



//void displayHp(string entity)
//{
//    Write("Player hp ");
//    Write(CurrentHp);
//    Write("/");
//    WriteLine(MaxHp);
//}




while (isRunning)
{

    key = ReadKey(true);
    if (key.Key == ConsoleKey.F)
    {
        WriteLine("choose player class :");
        foreach(string element in playerClass)
        {
            Write("- ");
            WriteLine(element);
        }
        string choseClass = ReadLine();
        player.initPlayer(choseClass);
        ennemy.initEnnemy();
        player.displayHp();     
        ennemy.displayHp();     
        isFighting = true;

    }


    if (key.Key == ConsoleKey.G)
    {
        player.initPlayer("Knight");
        ennemy.initEnnemy();
        player.displayHp();
        ennemy.displayHp();
        isFighting = true;

    }


    WriteLine(isFighting);
    while(isFighting){


        if(player.Speed - ennemy.Speed <= 0)
        {
            if (!ennemy.Dead) { ennemy.ennemyAction(player.Type); PlayerTakeDmg(); }
            else
            {
                WriteLine("Ennemy died");
                isFighting = false;
                break;
            }
            if (!player.Dead) { player.PlayerAction(ennemy.Type); ennemyTakeDmg(); }
            else
            {
                WriteLine("Player died");
                isFighting = false;
                break;
            }
        } 
        else
        {
            if (!player.Dead) { player.PlayerAction(ennemy.Type); ennemyTakeDmg(); }
            else
            {
                WriteLine("Player died");
                isFighting = false;
                break;
            }
            if (!ennemy.Dead) { ennemy.ennemyAction(player.Type); PlayerTakeDmg(); }
            else
            {
                WriteLine("Ennemy died");
                isFighting = false;
                break;
            }
        }
        


        
    }    
}

void PlayerTakeDmg()
{
    Write("player hp ");
    Write(player.CurrentHp);
    Write(" - ");
    WriteLine(ennemy.DmgOutput);
    player.CurrentHp = player.CurrentHp - ennemy.DmgOutput;
    if (player.CurrentHp <= 0) { player.CurrentHp = 0; player.Dead = true; }
    else { player.Dead = false; }
    Write("player hp ");
    WriteLine(player.CurrentHp);
}

void ennemyTakeDmg()
{
    Write("ennemy hp ");
    Write(ennemy.CurrentHp);
    Write(" - ");
    WriteLine(ennemy.DmgOutput);
    ennemy.CurrentHp = ennemy.CurrentHp - ennemy.DmgOutput;
    if (ennemy.CurrentHp <= 0) { ennemy.CurrentHp = 0; ennemy.Dead = true; }
    else { ennemy.Dead = false; }
    Write("ennemy hp ");
    WriteLine(ennemy.CurrentHp);
}

