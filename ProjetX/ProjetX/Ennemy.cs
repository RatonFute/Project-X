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
        private float currentHp;
        private float maxHp = 100;
        private float currentAtk;
        private float atk = 10;
        private float dmgOutput;
        private float speed;
        private int type;
        private int givenXp;
        private bool turnEnd;
        private bool dead = false;
       

        public float CurrentHp { get => currentHp; set => currentHp = value; }
        public float MaxHp { get => maxHp; set => maxHp = value; }
        public float CurrentAtk { get => currentAtk; set => currentAtk = value; }
        public float Speed { get => speed; set => speed = value; }
        public int Type { get => type; set => type = value; }
        public int GivenXp { get => givenXp; set => givenXp = value; }
        public float Atk { get => atk; set => atk = value; }
        public bool TurnEnd { get => turnEnd; set => turnEnd = value; }
        public bool PlayerDead { get => dead; set => dead = value; }

        public float ennemyAction(float playerHp, int playerType)
        {
            
            Console.WriteLine("ennemy is attacking");
            if ((type == 1 && playerType == 2) || (type == 2 && playerType == 3) || (type == 3 && playerType == 1)) { dmgOutput = currentAtk * 0.5f; givenXp = 20; }
            else if ((type == 2 && playerType == 1) || (type == 3 && playerType == 2) || (type == 1 && playerType == 3)) { dmgOutput = currentAtk * 2f; givenXp = 40; }
            else { dmgOutput = currentAtk;givenXp = 30; }
            Console.Write("player hp ");
            Console.Write(playerHp);
            Console.Write(" - ");
            Console.WriteLine(dmgOutput);
            playerHp = playerHp - dmgOutput;
            if (playerHp <= 0) { playerHp = 0; PlayerDead = true; }
            else { PlayerDead = false; }
            Console.Write("player hp ");
            Console.WriteLine(playerHp);
            TurnEnd = true;
            return playerHp;
        }



        public void displayHp()
        {
            Console.Write("Ennemy hp ");
            Console.Write(currentHp);
            Console.Write("/");
            Console.WriteLine(maxHp);
        }
        
    }
}
