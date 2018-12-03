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
            Game.PlayBattleShip();
            Console.ReadLine();
        }
    }
}
