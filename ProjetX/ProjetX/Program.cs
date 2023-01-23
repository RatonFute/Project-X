// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ConsoleKeyInfo key;
int ennemyHp = 100;
int ennemyCurrentHp;
int ourHp = 100;
int ourCurrentHp;
int ourAtk = 10;
int ennemyAtk = 10;
int ourCurrentAtk;
int ennemyCurrentAtk;
bool isRunning = true;
bool isFighting = false;
int buffDuration= 0;
bool buff = false;
int atkBuff = 10;
Console.WriteLine("|");
List<string> list = new List<string>() { "pot", "gem" };

while (isRunning)
{
    key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.F)
    {
        isFighting = true;
    }
    ourCurrentHp = ourHp;
    ennemyCurrentHp = ennemyHp;
    ourCurrentAtk = ourAtk;
    ennemyCurrentAtk = ennemyAtk;
    
    Console.WriteLine(isFighting);
    while(isFighting){
        Console.WriteLine("choose action:");
        Console.WriteLine("- obj");
        Console.WriteLine("- atk");
        string opt = Console.ReadLine();
        switch (opt)
        {
            case "obj":
                Console.WriteLine("Inventory : ");
                foreach(string element in list)
                {
                    Console.Write("- ");
                    Console.WriteLine(element);
                }
                string opta = Console.ReadLine();
                switch (opta)
                {
                    case "pot": 
                        Console.WriteLine("potion choosed");
                        ourCurrentHp = ourCurrentHp + 10;
                        Console.WriteLine("hp healed");
                        Console.Write("hp : ");
                        Console.WriteLine(ourCurrentHp);
                        break;
                    case "gem":
                        Console.WriteLine("gem choosed");
                        buffDuration = 2;
                        buff = true;
                        ourCurrentAtk = ourCurrentAtk + atkBuff;
                        Console.WriteLine("Attack increased !");
                        Console.Write("atk : ");
                        Console.WriteLine(ourCurrentAtk);
                        
                        break;
                }
                break;
            case "atk":
                Console.WriteLine("atk choosed");
                if(buffDuration >= 0 && buff)
                {
                    Console.WriteLine("buff");
                    Console.Write("atk : ");
                    Console.WriteLine(ourCurrentAtk);
                    buffDuration -= 1;
                }
                ennemyCurrentHp = ennemyCurrentHp - ourCurrentAtk;
                Console.Write("ennemy hp = ");
                Console.WriteLine(ennemyCurrentHp);
                if (buffDuration <= 0)
                {
                    buff = false;
                    ourCurrentAtk = ourAtk;
                    Console.WriteLine("buff faded");
                    Console.Write("atk : ");
                    Console.WriteLine(ourCurrentAtk);
                }
                break;
                 
              
        }
        Console.WriteLine("ennemy is attacking");
        ourCurrentHp = ourCurrentHp - ennemyCurrentAtk;
        Console.Write("hp ");
        Console.Write(ourCurrentHp);
        Console.Write("/");
        Console.WriteLine(ourHp);
    }
    
}




