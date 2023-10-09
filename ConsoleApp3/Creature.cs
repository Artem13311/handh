using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace HeadNHands
{
    class Creature
    {
        protected int attack { get; set; }
        protected int defense { get; set; }
        protected double health { get; set; }
        protected double maxHealth { get; set; }
        protected int[] damageRange { get; set; }
        protected bool creatureIsDeath;


        public Creature(int attack, int defense, double maxHealth, double health,int[] damageRange, bool creatureIsDeath = false)
        {
            if (attack < 1 || attack >30)
                throw new ArgumentException("Значение атаки должно быть в диапазоне (1-30)");

            if (defense < 1 || defense >30)
                throw new ArgumentException("Значение защиты должно быть в диапазоне (1-30)");

            if(health <0 || health > maxHealth)
                throw new ArgumentException($"Значение здоровья должно быть в диапазоне (0-{maxHealth})");
            if (damageRange.Length > 2)
            {
                throw new ArgumentException($"Размер массива значений урона не должен быть больше 2");

            }
           


            this.attack = attack;
            this.defense = defense;
            this.health = health;
            this.maxHealth = maxHealth;
            this.damageRange = damageRange;
            this.creatureIsDeath = creatureIsDeath;

        }



        public double getMaxHealth() {
            return maxHealth;
        }

        

        public void getAttack(Creature creature)
        {
            int atkMod = this.attack - creature.defense + 1;
            Random rnd = new Random();
            if (missOrNot(atkMod, rnd))
            {
                int attackDamage = rnd.Next(damageRange[0], damageRange[1]+1);
                creature.health -= attackDamage;
                if (creature is Monster)
                    Console.WriteLine($"Вы попали по монстру и нанесли {attackDamage} - урона.\nУ монстра {creature.health} хп из {creature.maxHealth}.");
                else
                    Console.WriteLine($"Монстр попал по вам и нанес {attackDamage} - урона.\nУ вас {creature.health} хп из {creature.maxHealth}.");

            }
            else
            {
                if (creature is Monster)
                    Console.WriteLine($"Неудача! Вы промазали по монстру!");
                else
                    Console.WriteLine($"Повезло! Монстр промазал по вам!");


            }
        }



        bool missOrNot(int atkModification, Random rnd)
        {
            bool flag = false;
            int Randnum;
            for (int i = 0; i < atkModification; i++)
            {
                Randnum = rnd.Next(1, 6);
                if(Randnum >= 5)
                {
                    flag = true;
                }
                else
                {
                    flag = false ;

                }
            }


            return flag;
        }

        public virtual void CheckHealth() { }
        public virtual bool getDeathInfo() => false;

        public void printHealth()
        {
            Console.WriteLine(health);
        }
        public void printMaxHealth()
        {
            Console.WriteLine(maxHealth);
        }

        public double getHealth()
        {
            return health;
        }

        


    }

}
