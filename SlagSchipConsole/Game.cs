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
            MockData();
            //printArray(posC);

            //while (Battleships.Count > 0)
            //{
            //    Console.WriteLine("Choose x:");
            //    int k = Int32.Parse(Console.ReadLine());
            //    Console.WriteLine("Choose y: ");
            //    int l = Int32.Parse(Console.ReadLine());
            //    Console.WriteLine("Choose direction d : r");
            //    string m = Console.ReadLine();

            //    SetShip(k, l, m, posP, Battleships);

            //    printArray(posP);
            //}

            PlayGame();
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
            if (Battleships.Count != 0)
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

        /// <summary>
        /// Mock data for test array Computer player
        /// </summary>
        public static void MockData()
        {
            int k = 0;
            int l = 1;
            string m = "r";
            SetShip(k, l, m, posC, BattleshipsC);//5

            k = 3;
            l = 4;
            m = "d";
            SetShip(k, l, m, posC, BattleshipsC);//4

            k = 2;
            l = 0;
            m = "d";
            SetShip(k, l, m, posC, BattleshipsC);//4

            k = 0;
            l = 7;
            m = "r";
            SetShip(k, l, m, posC, BattleshipsC);//3

            k = 2;
            l = 6;
            m = "d";
            SetShip(k, l, m, posC, BattleshipsC);//3

            k = 5;
            l = 8;
            m = "d";
            SetShip(k, l, m, posC, BattleshipsC);//3

            k = 6;
            l = 6;
            m = "d";
            SetShip(k, l, m, posC, BattleshipsC);//2

            k = 7;
            l = 1;
            m = "d";
            SetShip(k, l, m, posC, BattleshipsC);//2

            k = 2;
            l = 8;
            m = "r";
            SetShip(k, l, m, posC, BattleshipsC);//2

            k = 9;
            l = 8;
            m = "r";
            SetShip(k, l, m, posC, BattleshipsC);//2
        }

        public static void PlayGame()
        {
            bool game = true;

            while(game)
            {
                Console.WriteLine("Pick x and y");
                int x = Int32.Parse(Console.ReadLine());
                int y = Int32.Parse(Console.ReadLine());

                if(posC[x,y] == 1)
                {
                    Console.WriteLine("Hit!");
                    posC[x, y]++;
                    hitCountP++;
                }
                else
                {
                    Console.WriteLine("Miss!");
                }

                for(int i = 0;i < 10;i++)
                {
                    for(int j = 0; j < 10; j++)
                    {
                        if (posC[i,j] == 2)
                        {
                            Console.Write("2");
                        }
                        else
                        {
                            Console.Write("0");
                        }
                    }
                    Console.WriteLine();
                }

                x = rand1.Next(0,9);
                y = rand1.Next(0,9);

                if(posP[x,y] == 1)
                {
                    Console.WriteLine("Computer has a hit!");
                    posP[x, y]++;
                    hitCountC++;
                }
                else
                {
                    Console.WriteLine("Computer misses");
                }

                if(hitCountP == 30)
                {
                    Console.WriteLine("Player Win!");
                    game = false;
                }
                else if(hitCountC == 30)
                {
                    Console.WriteLine("Computer win!");
                    game = false;
                }
            }
        }
    }
}