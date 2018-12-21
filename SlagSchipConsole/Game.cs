using System;
using System.Collections.Generic;


namespace SlagSchipConsole
{
    public class Game
    {
        public static int[,] posP = new int[10, 10];
        public static int[,] posC = new int[10, 10];

        public static Stack<int> Battleships = new Stack<int>();
        public static Stack<int> BattleshipsC = new Stack<int>();
        

        public static int x = -1;
        public static int y = -1;
        public static string dir;
        public static int count;
        public static bool game = true;
        public static int hitCountP = 0;
        public static int hitCountC = 0;
        public static int z = 0;

        public static Random rand1 = new Random();

        public static void PlayBattleShip()
        {    
            #region fill battleship stack
            //Fill battleship stack
            Battleships.Push(2);
            Battleships.Push(2);
            Battleships.Push(2);
            Battleships.Push(2);
            Battleships.Push(3);
            Battleships.Push(3);
            Battleships.Push(3);
            Battleships.Push(4);
            Battleships.Push(4);
            Battleships.Push(5);

            BattleshipsC.Push(2);
            BattleshipsC.Push(2);
            BattleshipsC.Push(2);
            BattleshipsC.Push(2);
            BattleshipsC.Push(3);
            BattleshipsC.Push(3);
            BattleshipsC.Push(3);
            BattleshipsC.Push(4);
            BattleshipsC.Push(4);
            BattleshipsC.Push(5);
            #endregion C

            Console.WriteLine("welcome to Battleship");
           
            while (BattleshipsC.Count > 0)
            {
                x = rand1.Next(0, 9);
                y = rand1.Next(0, 9);

                string dir = "r";

                if (z == 0)
                {
                    dir = "r";
                    z = 1;
                }
                else
                {
                    dir = "d";
                    z = 0;
                }

                SetShip(x, y, dir, posC, BattleshipsC);              
            }

            printArray(posC);

            while (Battleships.Count > 0)
            {
                Console.WriteLine("Choose x:");
                int k = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Choose y: ");
                int l = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Choose direction d : r");
                string m = Console.ReadLine();

                SetShip(k, l, m, posP, Battleships);

                printArray(posP);
            }

        }

        #region SetShip method
        /// <summary>
        /// k and l are the coordinates of the ship and m is the direction of how the ship wil be set
        /// It wil first check with the method CanPlace if the ship can be placed before performing a set, the length of the ship is determined by the size
        /// of the int that is stored in the stack "battleships"
        /// </summary>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        public static void SetShip(int k, int l, string m, int[,] pos, Stack<int> Battleships)
        {
            if (GameLogic.CheckShipPositions(pos, k, l, m, Battleships.Peek()))
            {
                if (m == "d")
                {
                    for (int i = 0; i < Battleships.Peek(); i++)
                    {
                        pos[k + i, l] = 1;
                    }
                }
                else if (m == "r")
                {
                    for (int i = 0; i < Battleships.Peek(); i++)
                    {
                        pos[k, l + i] += 1;
                    }
                }

                Battleships.Pop();
            }
        }
        #endregion

        /// <summary>
        /// !!!! needs Work !!!!
        /// </summary>
        #region Shoot
        public static void Shoot(int k, int l)
        {
            int i = posP[k, l];

            if (i == 1)
            {
                posP[k, l] = 2;
                hitCountP++;
            }
        }
        #endregion


        #region Print array method  
        public static void printArray(int[,] arr)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion        
    }
}