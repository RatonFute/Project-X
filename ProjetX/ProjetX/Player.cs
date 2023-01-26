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
        private float maxHp = 100;
        private float heal = 30;
        private float currentAtk;
        private float atk = 10;
        private float magicAtk = 5;
        private float currentMagicAtk;
        private float physicAtk = 5;
        private float currentPhysicAtk;
        private float dmgOutput;
        private float speed = 50;
        private int type;
        private int atkBuffDuration;
        private float atkBuff = 10;
        private bool buffed;
        private bool turnEnd = true;
        private bool dead = false;
        List<string> inventory = new List<string>() { "pot", "gem" };
        List<string> ability = new List<string>() { "sword", "fireball" };

        public float CurrentHp
        {
            get => currentHp;
            set
            {
                currentHp = value;
                if (currentHp < 0) { currentHp = 0; }
            }
        }
        public int XP { get; set; }
        public int LVL { get; set; }
        public List<string> Inventory { get => inventory; set => inventory = value; }
        public float MaxHp { get => maxHp; }
        public int Type { get => type; set => type = value; }
        public float CurrentAtk { get => currentAtk; set => currentAtk = value; }
        public float Atk { get => atk = atk + (LVL * 1.5f); private set => atk = value; }
        public float Speed { get => speed; set => speed = value; }
        private float AtkBuff { get => atkBuff = atkBuff + (LVL * 1.5f); }
        public bool TurnEnd { get => turnEnd; set => turnEnd = value; }
        public float MagicAtk { get => magicAtk; set => magicAtk = value; }
        public float CurrentMagicAtk { get => currentMagicAtk; set => currentMagicAtk = value; }
        public float CurrentPhysicAtk { get => currentPhysicAtk; set => currentPhysicAtk = value; }
        public float PhysicAtk { get => physicAtk; set => physicAtk = value; }
        public bool Dead { get => dead; set => dead = value; }

        public float PlayerAction(float ennemyCurrentHp, int ennemyType)
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
                    
                    string opta = Console.ReadLine();
                    if (opta == "pot")
                    {
                        Console.WriteLine("-----------potion choosed");
                        Console.WriteLine("hp healed");
                        Console.Write("hp ");
                        Console.Write(CurrentHp);
                        Console.Write(" + ");
                        Console.Write(heal);
                        CurrentHp = CurrentHp + heal;
                        TurnEnd = true;
                    }
                    else if(opta == "gem")
                    {
                        Console.WriteLine("----------gem choosed");
                        atkBuffDuration = 2;
                        buffed = true;
                        CurrentAtk = CurrentAtk + AtkBuff;
                        Console.WriteLine("Attack increased !");
                        Console.Write("atk is now ");
                        Console.WriteLine(CurrentAtk);
                        TurnEnd = true;
                    }
                    else { TurnEnd = false; }

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

                    string optb = Console.ReadLine();
                    if (optb == "sword")
                    {
                        dmgOutput = dmgOutput + (CurrentPhysicAtk / 2);
                        Console.WriteLine("You use your sword to slice your ennemies !");
                                              
                        TurnEnd = true;
                    }
                    else if (optb == "fireball")
                    {
                        dmgOutput = dmgOutput + (CurrentMagicAtk / 5);
                        Console.WriteLine("You throw a fire ball to your ennemies !");
                        TurnEnd = true;
                    }
                    else { TurnEnd = false; }

                    if ((type == 1 && ennemyType == 2) || (type == 2 && ennemyType == 3) || (type == 3 && ennemyType == 1)) { dmgOutput = dmgOutput * 0.5f; }
                    else if ((type == 2 && ennemyType == 1) || (type == 3 && ennemyType == 2) || (type == 1 && ennemyType == 3)) { dmgOutput = dmgOutput * 2f; }

                    Console.Write("ennemy hp ");
                    Console.Write(ennemyCurrentHp);
                    Console.Write(" - ");
                    Console.WriteLine(dmgOutput);
                    ennemyCurrentHp = ennemyCurrentHp - dmgOutput;
                    if (ennemyCurrentHp <= 0) { ennemyCurrentHp = 0; Dead = true; }
                    else { Dead = false; }
                    Console.Write("ennemy hp ");
                    Console.WriteLine(ennemyCurrentHp);
                    break;

            }

           

            return ennemyCurrentHp;

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
