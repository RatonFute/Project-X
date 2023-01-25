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
        public float currentHp;
        public float maxHp;
        public float currentAtk;
        public float atk = 10;
        public float dmgOutput;
        public float speed;
        public int type;
        public int givenXp;
        
        public int AtkBuffDuration;
        public float AtkBuff;
        public float ennemyAction(float playerHp, int playerType)
        {
            
            Console.WriteLine("ennemy is attacking");
            if ((type == 1 && playerType == 2) || (type == 2 && playerType == 3) || (type == 3 && playerType == 1)) { dmgOutput = currentAtk * 0.5f; givenXp = 20; }
            else if ((type == 2 && playerType == 1) || (type == 3 && playerType == 2) || (type == 1 && playerType == 3)) { dmgOutput = currentAtk * 2f; givenXp = 40; }
            else { dmgOutput = currentAtk;givenXp = 30; }

            playerHp = playerHp - dmgOutput;
            return playerHp;
        }



        public void displayHp()
        {
            Console.Write("hp ");
            Console.Write(currentHp);
            Console.Write("/");
            Console.WriteLine(maxHp);
        }
        
    }
}
