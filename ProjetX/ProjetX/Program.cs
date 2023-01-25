// See https://aka.ms/new-console-template for more information
using ProjetX;

Console.WriteLine("Hello, World!");
ConsoleKeyInfo key;
int feu = 1;
int eau = 2;
int plant = 3;
bool isRunning = true;
bool isFighting = false;
Console.WriteLine("----------------------------------");



while (isRunning)
{

    Player wui = new Player();
    wui.CurrentHp = wui.MaxHp;
    wui.CurrentAtk = wui.Atk;
    wui.Type = feu;

    Ennemy gromp = new Ennemy();
    gromp.currentHp = gromp.maxHp;
    gromp.type = feu;


    key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.F)
    {
        wui.CurrentHp = wui.MaxHp;
        gromp.currentHp = gromp.maxHp;
        wui.CurrentAtk = wui.atk;
        gromp.currentAtk = gromp.atk;
        isFighting = true;

    }
    
    
    Console.WriteLine(isFighting);
    while(isFighting){
        

        
    }


    
}




