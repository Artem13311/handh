using HeadNHands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadNHands
{
    class Monster : Creature
    {
        public Monster(int attack, int defense, double maxHealth, double health,  int[] damageRange, bool creatureIsDeath = false) :
            base(attack, defense, maxHealth, health, damageRange, creatureIsDeath)
        { }
        public override void CheckHealth()
        {
            if (health <= 0)
            {
                Console.WriteLine("Вы убили монстра!");
                creatureIsDeath = true;

            }
        }

        public override bool getDeathInfo()
        {
            return creatureIsDeath;

        }
    }

}
