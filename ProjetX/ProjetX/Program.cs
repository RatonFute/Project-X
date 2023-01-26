// See https://aka.ms/new-console-template for more information
using ProjetX;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");
ConsoleKeyInfo key;
int feu = 1;
int eau = 2;
int plant = 3;
bool isRunning = true;
bool isFighting = false;
Console.WriteLine("----------------------------------");
Player wui = new Player();
Ennemy gromp = new Ennemy();
void initPlayer() {
    
    wui.CurrentHp = wui.MaxHp;
    wui.Atk = 10;
    wui.MagicAtk = 2;
    wui.PhysicAtk = 5;
    wui.CurrentAtk = wui.Atk;
    wui.CurrentMagicAtk = wui.MagicAtk;
    wui.CurrentPhysicAtk = wui.PhysicAtk;
    wui.Speed = 60;
    wui.Type = feu;
}
void initGromp()
{
    
    gromp.Atk = 15;
    gromp.CurrentAtk = gromp.Atk;
    gromp.CurrentHp = gromp.MaxHp;
    gromp.Speed = 50;
    gromp.Type = feu;
}

while (isRunning)
{

    initPlayer();
    initGromp();

    


    key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.F)
    {
       
        wui.displayHp();
        gromp.displayHp();
        isFighting = true;

    }
    
    
    Console.WriteLine(isFighting);
    while(isFighting){
        if((wui.Speed - gromp.Speed) <= 0)
        {

            if (!wui.Dead) { wui.CurrentHp = gromp.ennemyAction(wui.CurrentHp, wui.Type); }
            else 
            {
                Console.WriteLine("Ennemy died");
                isFighting = false;
                break;
            }
            if (!gromp.PlayerDead) { gromp.CurrentHp = wui.PlayerAction(gromp.CurrentHp, gromp.Type); }
            else
            {
                Console.WriteLine("Player died");
                isFighting = false;
                break;
            }
        }
        else
        {
            if (!gromp.PlayerDead) { gromp.CurrentHp = wui.PlayerAction(gromp.CurrentHp, gromp.Type); }
            else
            {
                Console.WriteLine("Player died");
                isFighting = false;
                break;
            }
            if (!wui.Dead) { wui.CurrentHp = gromp.ennemyAction(wui.CurrentHp, wui.Type); }
            else
            {
                Console.WriteLine("Ennemy died");
                isFighting = false;
                break;
            }
        }        
    }    
}




