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

        public static Random rand1 = new Random();
        public static Random rand2 = new Random();

        public static void PlayBattleShip()
        {
            //initialize pos array's
            #region initialize pos array
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    posP[i, j] = 0;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    posC[i, j] = 0;
                }
            }
            #endregion

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

            SetShipComp(BattleshipsC, posC);

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
            if (CanPlace(k, l, m, pos, Battleships))
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

        #region CanPlace method
        public static bool CanPlace(int k, int l, string d, int[,] pos, Stack<int> Battleships)
        {
            if (!(Battleships.Peek() + k > 8) && !(Battleships.Peek() + l > 8))
            {
                if (k > 0 && l > 0 && k < 9 && l < 9)
                {
                    if (d == "d")
                    {
                        for (int i = 0; i < Battleships.Peek(); i++)
                        {
                            if (pos[k, l] == 1 ||
                                pos[k - 1, l] == 1 ||
                                pos[k - 1, l - 1] == 1 ||
                                pos[k - 1, l + 1] == 1 ||
                                pos[k, l - 1] == 1 ||
                                pos[k, l + 1] == 1 ||
                                pos[k + 1 + i, l - 1] == 1 ||
                                pos[k + 1 + i, l] == 1 ||
                                pos[k + 1 + i, l + 1] == 1)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Battleships.Peek(); i++)
                        {
                            if (pos[k, l] == 1 ||
                               pos[k - 1, l] == 1 ||
                               pos[k - 1, l - 1] == 1 ||
                               pos[k - 1, l + 1 + i] == 1 ||
                               pos[k, l - 1] == 1 ||
                               pos[k, l + 1 + i] == 1 ||
                               pos[k + 1, l - 1] == 1 ||
                               pos[k + 1, l] == 1 ||
                               pos[k + 1, l + 1 + i] == 1
                               )
                            {
                                return false;
                            }
                        }
                    }
                }

                if (k < 1 && l < 1)
                {
                    if (d == "d")
                    {
                        for (int i = 0; i < Battleships.Peek(); i++)
                        {
                            if (pos[k,l] == 1 ||
                                pos[k + 1 + i,l] == 1 ||
                                pos[k + 1 + i,l + 1] == 1 ||
                                pos[k, l + 1] == 1)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Battleships.Peek(); i++)
                        {
                            if(pos[k,l] == 1 ||
                                pos[k,l + 1 + i] == 1 ||
                                pos[k + 1,l + 1 + i] == 1 ||
                                pos[k + 1,l] == 1)
                            {
                                return false;
                            }
                        }
                    }
                }

                if (k > 0 && l < 1)
                {
                    if (d == "d")
                    {
                        for (int i = 0; i < Battleships.Peek(); i++)
                        {
                            if (pos[k - 1,l] == 1 ||
                                pos[k,l] == 1 ||
                                pos[k - 1,l + 1] == 1||
                                pos[k + 1 + i,l] == 1 ||
                                pos[k + 1 + i, l + 1 + i] == 1)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Battleships.Peek(); i++)
                        {
                            if( pos[k,l] == 1 ||
                                pos[k - 1,l + i] == 1 ||
                                pos[k - 1,l + i ] == 1 ||
                                pos[k - 1,l + i + 1] == 1 ||
                                pos[k, l + 1 + i] == 1 ||
                                pos[k + 1,l] == 1 ||
                                pos[k + 1,l + 1 + i] == 1)
                            {
                                return false;
                            }
                        }
                    }
                }

                if(k < 1 && l > 8 && d == "d")
                {
                    for (int i = 0; i < Battleships.Peek(); i++)
                    {
                        if (pos[k,l] == 1 ||
                            pos[k + i, l - 1] == 1 ||
                            pos[k+i,l] == 1 ||
                            pos[k+i,l+i] == 1)
                        {
                            return false;
                        }
                    }
                }
                 
                if (k > 1 && l > 8 && d == "d")
                {
                    for (int i = 0; i < Battleships.Peek(); i++)
                    {
                        if (pos[k, l] == 1 ||
                            pos[k + i, l - 1] == 1 ||
                            pos[k + i, l] == 1 ||
                            pos[k + i, l + i] == 1 ||
                            pos[k - 1,l] == 1 ||
                            pos[k - 1,l - 1] == 1 ||
                            pos[k,l - 1] == 1)
                        {
                            return false;
                        }
                    }
                }

                if (k > 8 && l == 0 && d == "r")
                {
                    for (int i = 0; i < Battleships.Peek(); i++)
                    {
                        if(pos[k,l] == 1 ||
                           pos[k - 1,l] == 1 ||
                           pos[k - 1,l + 1 + i] == 1 ||
                           pos[k,l + 1 + i] == 1)
                        {
                            return false;
                        }
                    }
                }

                if(k > 8 && l > 0 && d == "r")
                {
                    for (int i = 0; i < Battleships.Peek(); i++)
                    {

                    }
                }
            }

            return true;
        }
        #endregion

        /// <summary>
        /// !!!! needs Work !!!!
        /// </summary>
        #region Shoot
        public static void Shoot()
        {
            int l = 0;
            int k = 0;

            do
            {
                Console.WriteLine("Choose x: ");
                l = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Choose y: ");
                k = Int32.Parse(Console.ReadLine());
            }
            while (k < 0 && l < 0);

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

        #region Set Comp Battleships
        public static void SetShipComp(Stack<int> BattleShips, int[,] pos)
        {
            while (BattleShips.Count != 0)
            {
                int i = rand1.Next(0, 10);
                int j = rand1.Next(0, 10);

                int k = rand2.Next(0,5000);
                string dir = "r";

                if(k > 2500)
                {
                    dir = "d";
                }

                if (CanPlace(i, j, dir, pos, Battleships))
                {
                    if (dir == "d")
                    {
                        for (int x = 0; x < Battleships.Peek(); x++)
                        {
                            pos[i + x, j] = 1;
                        }
                    }
                    else if (dir == "r")
                    {
                        for (int x = 0; x < Battleships.Peek(); x++)
                        {
                            pos[i, j + x] += 1;
                        }
                    }
                    printArray(pos);
                }
            }
        }
        #endregion
    }
}