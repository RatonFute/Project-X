using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProjetX
{
    public class Player
    {
        private float currentHp;
        private float maxHp;
        private float mana;
        private float currentMana;
        private float heal;
        private int critRate;
        private float critDmg;
        private float currentAtk;
        private float atk;
        private float magicAtk;
        private float currentMagicAtk;
        private float physicAtk;
        private float currentPhysicAtk;
        private float dmgOutput;
        private float speed;
        private int type;
        private int atkBuffDuration;
        int feu = 1;
        int eau = 2;
        int plant = 3;
        private float atkBuff = 10;
        private bool buffed;
        private bool dead = false;
        List<string> inventory = new List<string>() { "pot", "gem", "gem+" };
        List<string> ability = new List<string>() { "sword", "fireball" };

        public float CurrentHp
        {
            get => currentHp;
            set => currentHp = value;
        }
        public int XP { get; set; }
        public int LVL { get; set; }
        public List<string> Inventory { get => inventory; set => inventory = value; }
        public float MaxHp { get => maxHp; set => maxHp = value; }
        public int Type { get => type; set => type = value; }
        public float Atk { get => atk = atk + (LVL * 1.5f);  set => atk = value; }
        public float MagicAtk { get => magicAtk = magicAtk + (LVL * 1.1f); set => magicAtk = value; }
        public float PhysicAtk { get => physicAtk; set => physicAtk = value; }
        public float CurrentAtk { get => currentAtk; set => currentAtk = value; }
        public float CurrentMagicAtk { get => currentMagicAtk; set => currentMagicAtk = value; }
        public float CurrentPhysicAtk { get => currentPhysicAtk; set => currentPhysicAtk = value; }
        public float Speed { get => speed; set => speed = value; }
        private float AtkBuff { get => atkBuff = atkBuff + (LVL * 1.2f); }        
        public bool Dead { get => dead; set => dead = value; }
        public int CritRate { get => critRate; set => critRate = value; }
        public float CritDmg { get => critDmg; set => critDmg = value; }


        public void initWarrior()
        {
            MaxHp = 120;
            CurrentHp = MaxHp;
            Atk = 20;
            MagicAtk = 1;
            PhysicAtk = 10;
            CurrentAtk = Atk;
            CurrentMagicAtk = MagicAtk;
            CurrentPhysicAtk = PhysicAtk;
            Speed = 30;
            Type = feu;
            Console.WriteLine("you chose warrior");
        }
        public void initWizard()
        {
            MaxHp = 70;
            CurrentHp = MaxHp;
            Atk = 5;
            MagicAtk = 15;
            PhysicAtk = 2;
            CurrentAtk = Atk;
            CurrentMagicAtk = MagicAtk;
            CurrentPhysicAtk = PhysicAtk;
            Speed = 60;
            Type = eau;
            Console.WriteLine("you chose wizard");
        }
        public void initKnight()
        {
            MaxHp = 100;
            CurrentHp = MaxHp;
            Atk = 15;
            MagicAtk = 8;
            PhysicAtk = 10;
            CurrentAtk = Atk;
            CurrentMagicAtk = MagicAtk;
            CurrentPhysicAtk = PhysicAtk;
            Speed = 50;
            Type = plant;
            Console.WriteLine("you chose knight");
        }

        public void initPlayer(string _playerClass)
        {
            if (_playerClass == "warrior")
            {
                initWarrior();
            }
            else if (_playerClass == "knight")
            {
                initKnight();
            }
            else if (_playerClass == "wizard")
            {
               initWizard();
            }
            
        }

        public void PlayerAction(int ennemyType)
        {
            Console.WriteLine("You are playing");
            Console.WriteLine("choose an action:");
            Console.WriteLine("- obj");
            Console.WriteLine("- atk");
            string opt = Console.ReadLine();
            switch (opt)
            {
                case "obj":
                    Console.WriteLine("---------Inventory : ");
                    foreach (string element in inventory)
                    {
                        Console.Write("- ");
                        Console.WriteLine(element);
                    }
                    int i = 0;
                    string opta = Console.ReadLine();
                    if (opta == inventory[i])
                    {
                        Console.WriteLine("-----------potion choosed");
                        Console.WriteLine("hp healed");
                        Console.Write("hp ");
                        Console.Write(CurrentHp);
                        Console.Write(" + ");
                        Console.Write(heal);
                        CurrentHp = CurrentHp + heal;
                        
                    }
                    i = i + 1;
                    if (opta == inventory[i])
                    {
                        Console.WriteLine("----------gem choosed");
                        atkBuffDuration = 2;
                        buffed = true;
                        CurrentAtk = CurrentAtk + AtkBuff;
                        Console.WriteLine("Attack increased !");
                        Console.Write("atk is now ");
                        Console.WriteLine(CurrentAtk);
                        
                    }
                    i = i + 1;
                    if (opta == inventory[i])
                    {
                        Console.WriteLine("----------gem+ choosed");
                        atkBuffDuration = 1;
                        buffed = true;
                        CurrentAtk = CurrentAtk + (AtkBuff * 5);
                        Console.WriteLine("Attack increased !");
                        Console.Write("atk is now ");
                        Console.WriteLine(CurrentAtk);
                        
                    }
                    

                    break;
                case "atk":
                    Console.WriteLine("----------atk choosed");
                    if (atkBuffDuration <= 0 && buffed)
                    {
                        buffed = false;
                        CurrentAtk = Atk;
                        Console.WriteLine("buff faded");
                        Console.Write("atk : ");
                        Console.WriteLine(CurrentAtk);
                    }
                    if (atkBuffDuration >= 0 && buffed)
                    {
                        Console.WriteLine("buff");
                        Console.Write("atk : ");
                        Console.WriteLine(CurrentAtk);
                        atkBuffDuration -= 1;
                    }

                    dmgOutput = CurrentAtk;

                    Console.WriteLine("---------Abilities : ");
                    foreach (string element in ability)
                    {
                        Console.Write("- ");
                        Console.WriteLine(element);
                    }
                    int j = 0;
                    string optb = Console.ReadLine();
                    if (optb == ability[j])
                    {
                        dmgOutput = dmgOutput + CurrentPhysicAtk;
                        Console.WriteLine("You use your sword to slice your ennemies !");
                        
                    }
                    j = j + 1;
                    if (optb == ability[j])
                    {
                        dmgOutput = dmgOutput + CurrentMagicAtk;
                        Console.WriteLine("You throw a fire ball to your ennemies !");
                     
                    }
                    

                    if ((type == 1 && ennemyType == 2) || (type == 2 && ennemyType == 3) || (type == 3 && ennemyType == 1)) { dmgOutput = dmgOutput * 0.5f; }
                    else if ((type == 2 && ennemyType == 1) || (type == 3 && ennemyType == 2) || (type == 1 && ennemyType == 3)) { dmgOutput = dmgOutput * 2f; }
                    Random rand = new Random();
                    if(rand.Next(101) <= CritRate) 
                    {
                        Console.WriteLine("you did a critical hit !");
                        dmgOutput = dmgOutput * CritDmg;
                    }
                    
                    break;

            }        

        }

        public void displayHp()
        {
            Console.Write("Player hp ");
            Console.Write(CurrentHp);
            Console.Write("/");
            Console.WriteLine(MaxHp);
        }
    }
}
