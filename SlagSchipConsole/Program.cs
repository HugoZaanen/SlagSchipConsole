using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlagSchipConsole
{
    class Program
    {
        public static Random rand = new Random();

        static void Main(string[] args)
        {
            //Game.PlayBattleShip();

            for(int j = 0;j < 3;j++)
            {
                int i = rand.Next(1, 10);
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
