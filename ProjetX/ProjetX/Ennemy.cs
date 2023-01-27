using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjetX
{
    internal class Ennemy
    {
        private float maxHp;
        private float currentHp;
        private float currentAtk;
        private float atk;
        private float dmgOutput;
        private float speed;
        private int type;
        private int givenXp;
        private bool turnEnd;
        private bool dead = false;
        int feu = 1;
        int eau = 2;
        int plant = 3;

        public int LVL { get; set; }
        public float MaxHp { get => maxHp; set => maxHp = value; }
        public float Speed { get => speed; set => speed = value; }
        public int Type { get => type; set => type = value; }
        public int GivenXp { get => givenXp; set => givenXp = value; }
        public float Atk { get => atk = atk + (LVL * 1.5f); set => atk = value; }
        public bool TurnEnd { get => turnEnd; set => turnEnd = value; }
        public bool Dead { get => dead; set => dead = value; }
        public float DmgOutput { get => dmgOutput; set => dmgOutput = value; }
        public float CurrentHp { get => currentHp; set => currentHp = value; }
        public float CurrentAtk { get => currentAtk; set => currentAtk = value; }

        public void ennemyAction(int playerType)
        {
            
            Console.WriteLine("ennemy is attacking");
            if ((type == 1 && playerType == 2) || (type == 2 && playerType == 3) || (type == 3 && playerType == 1)) { dmgOutput = CurrentAtk * 0.5f; givenXp = 20; }
            else if ((type == 2 && playerType == 1) || (type == 3 && playerType == 2) || (type == 1 && playerType == 3)) { dmgOutput = CurrentAtk * 2f; givenXp = 40; }
            else { dmgOutput = CurrentAtk; givenXp = 30; }
            
            TurnEnd = true;
           
        }

        public void Gromp()
        {
            MaxHp = 100;
            CurrentHp = MaxHp;
            Atk = 15;
            CurrentAtk = Atk;
            Speed = 50;
            Type = 1;
        }
        public void Cheval()
        {
            MaxHp = 60;
            CurrentHp = MaxHp;
            Atk = 25;
            CurrentAtk = Atk;
            Speed = 70;
            Type = 3;
        }
        
        public void initEnnemy()
        {
            Random rand = new Random();
            switch (rand.Next(2))
            {
                case 0: Gromp(); break;
                case 1: Cheval(); break;
            }
        }

        public void displayHp()
        {
            Console.Write("Ennemy hp ");
            Console.Write(CurrentHp);
            Console.Write("/");
            Console.WriteLine(MaxHp);
        }
    }
}
