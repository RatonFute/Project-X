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
    wui.Speed = 60;
    wui.Type = feu;

    Ennemy gromp = new Ennemy();
    gromp.CurrentHp = gromp.MaxHp;
    gromp.Speed = 50;
    gromp.Type = feu;


    key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.F)
    {
        wui.CurrentHp = wui.MaxHp;
        gromp.CurrentHp = gromp.MaxHp;
        wui.CurrentAtk = wui.Atk;
        gromp.CurrentAtk = gromp.Atk;
        wui.displayHp();
        gromp.displayHp();
        isFighting = true;

    }
    
    
    Console.WriteLine(isFighting);
    while(isFighting){
        if((wui.Speed - gromp.Speed) <= 0)
        {
            gromp.CurrentHp = wui.PlayerAction(gromp.CurrentHp, gromp.Type);
            wui.CurrentHp = gromp.ennemyAction(wui.CurrentHp, wui.Type);
      
        }
        else
        {
            wui.CurrentHp = gromp.ennemyAction(wui.CurrentHp, wui.Type);
            gromp.CurrentHp = wui.PlayerAction(gromp.CurrentHp, gromp.Type);
        }        
    }    
}




