using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadNHands
{
    
    class Program
    {
        static void Main(string[] args)
        {


            int[] damageRange = new int[2] { 1, 6};
            Player player = new Player(8, 5, 20, 20, damageRange);
            Monster monster1 = new Monster(5, 5, 20,20, damageRange);

            
            bool flag = true;
            string choice;

            do
            {
                Console.WriteLine("Введите нужный вариант где\n1)Ударить монстра\n2)Лечение ран\n3)Характеристики");

                choice = Console.ReadLine();

                switch (choice)
                {

                    case "1":
                        Console.WriteLine("---------------------------------");
                        player.getAttack(monster1);
                        monster1.CheckHealth();
                        if (monster1.getDeathInfo())
                        {
                            flag = false;

                            break;
                        }
                        monster1.getAttack(player);
                        player.CheckHealth();
                        if (player.getDeathInfo())
                        {
                            flag = false;
                            break;
                        }


                        Console.WriteLine("---------------------------------");
                        break;
                    case "2":
                        Console.WriteLine("---------------------------------");

                        player.heal();
                        Console.WriteLine("---------------------------------");

                        break;
                    case "3":
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine($"У вас {player.getHealth()} хп и {player.getHealCount()} хилялок");
                        Console.WriteLine("---------------------------------");

                        break;




                }


            } while (flag);


            Console.ReadKey();




        }
    }
}
