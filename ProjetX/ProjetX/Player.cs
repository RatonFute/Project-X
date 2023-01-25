using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProjetX
{
    internal class Player
    {
        private float currentHp;
        private float maxHp = 100;
        private float heal = 30;
        private float currentAtk;
        private float atk;
        private float dmgOutput;
        private float speed = 50;
        private int type;
        private int atkBuffDuration;
        private float atkBuff;
        private bool buffed;
        List<string> inventory = new List<string>() { "pot", "gem" };

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
        public float CurrentHp1 { get => currentHp; set => currentHp = value; }
        public float CurrentAtk { get => currentAtk; set => currentAtk = value; }
        public int Type { get => type; set => type = value; }
        public float Atk { get => atk = atk * (LVL * 1.5f); private set => atk = value; }
        public float Speed { get => speed; set => speed = value; }
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
                    Console.WriteLine("Inventory : ");
                    foreach (string element in inventory)
                    {
                        Console.Write("- ");
                        Console.WriteLine(element);
                    }
                    string opta = Console.ReadLine();
                    switch (opta)
                    {
                        case "pot":
                            Console.WriteLine("potion choosed");

                            Console.WriteLine("hp healed");
                            Console.Write("hp ");
                            Console.Write(currentHp);
                            Console.Write(" + ");
                            Console.Write(heal);
                            currentHp = currentHp + heal;
                            break;
                        case "gem":
                            Console.WriteLine("gem choosed");
                            atkBuffDuration = 2;
                            buffed = true;
                            currentAtk = currentAtk + atkBuff;
                            Console.WriteLine("Attack increased !");
                            Console.Write("atk is now ");
                            Console.WriteLine(currentAtk);

                            break;
                    }
                    break;
                case "atk":
                    Console.WriteLine("atk choosed");
                    if (atkBuffDuration >= 0 && buffed)
                    {
                        Console.WriteLine("buff");
                        Console.Write("atk : ");
                        Console.WriteLine(currentAtk);
                        atkBuffDuration -= 1;
                    }

                    if (atkBuffDuration <= 0)
                    {
                        buffed = false;
                        currentAtk = atk;
                        Console.WriteLine("buff faded");
                        Console.Write("atk : ");
                        Console.WriteLine(currentAtk);
                    }

                    if ((type == 1 && ennemyType == 2) || (type == 2 && ennemyType == 3) || (type == 3 && ennemyType == 1)) { dmgOutput = currentAtk * 0.5f; }
                    if ((type == 2 && ennemyType == 1) || (type == 3 && ennemyType == 2) || (type == 1 && ennemyType == 3)) { dmgOutput = currentAtk * 2f; }

                    Console.Write("buffed ");
                    Console.Write(atkBuffDuration);
                    Console.WriteLine(" turns");
                    Console.Write("ennemy hp ");
                    Console.Write(ennemyCurrentHp);
                    Console.Write(" - ");
                    Console.Write(dmgOutput);
                    ennemyCurrentHp = ennemyCurrentHp - dmgOutput;
                    break;

            }
            return ennemyCurrentHp;

        }

        public void displayHp()
        {
            Console.Write("hp ");
            Console.Write(currentHp);
            Console.Write("/");
            Console.WriteLine(MaxHp);
        }
    }
}
