using HeadNHands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadNHands
{
    class Player : Creature
    {
        int healCount = 4;

        public Player(int attack, int defense, double maxHealth, double health,  int[] damageRange, bool creatureIsDeath = false) :
            base(attack, defense, maxHealth, health, damageRange, creatureIsDeath)
        {
        }

        public void heal()
        {
            if (healCount != 0)
            {
                healCount--;
                if (health != maxHealth)
                {
                    health += (maxHealth / 100) * 30;
                    health = Math.Round(health, 0);
                    if (health > maxHealth)
                    {
                        health =   maxHealth;
                    }
                    Console.WriteLine($"Вы вылечились и вас теперь {health} хп!");

                    Console.WriteLine($"У вас осталось {healCount} лечения!");


                }
                else
                {
                    Console.WriteLine("У вас максимальное значение хп!");

                }
            }

            else
            {
                Console.WriteLine("Вы больше не можете излечиваться!");
            }

        }

        


        public override void CheckHealth()
        {
            if (health <= 0)
            {
                Console.WriteLine("Ваш персонаж умер!");
                creatureIsDeath = true;
            }
        }

        public override bool getDeathInfo()
        {
            return creatureIsDeath;
        }

        public int getHealCount()
        {
            return healCount;
        }


    }

}
