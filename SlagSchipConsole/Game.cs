using System;
using System.Collections.Generic;


namespace SlagSchipConsole
{
    public class Game
    {
        public static int[,] pos = new int[10,10];

        public static Stack<int> Battleships = new Stack<int>();
        public static int x = -1;
        public static int y = -1;
        public static string dir;
        public static int count;
        public static bool game = true;
        public static int hitCountP = 0;
        public static int hitCountC = 0;
        public static Random rand = new Random();

        public static void PlayBattleShip()
        {
            //initialize pos array
            #region initialize pos array
            for (int i = 0;i < 10;i++)
            {
                for (int j = 0;j < 10;j++)
                {
                    pos[i, j] = 0;
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
            #endregion

            while (game)
            {


                if (hitCountP == 30 || hitCountC == 30)
                {
                    game = false;
                }
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
        public static void SetShip(int k, int l, string m)
        {
            if (CanPlace(k,l,m))
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
        public static bool CanPlace(int k, int l, string d)
        {
            if (!(Battleships.Peek() + k > 9) && !(Battleships.Peek() + l > 9))
            {
                if (k > 0 && l > 0 && d == "d")
                {
                    for (int i = 0;i <= Battleships.Peek();i++)
                    {
                        if (   pos[k,l] == 1 
                            || pos[k - 1,l - 1] == 1 
                            || pos[k - 1,l] == 1 
                            || pos[k - 1, l + 1] == 1 
                            || pos[k + i,l - 1] == 1 
                            || pos[k + i,l] == 1 
                            || pos[k + i,l + 1] == 1)
                        {
                            return false;
                        }
                    }
                }
                
                if (k < 1 && l == 0 && d == "d")
                {
                    for (int i = 0;i <= Battleships.Peek();i++)
                    {
                        if (pos[k + 1,l] == 1 ||
                            pos[k + i,l + i] == 1 ||
                            pos[k + i,l + 1] == 1 ||
                            pos[k + i,l] == 1)
                        {
                            return false;
                        }
                    }
                }

                if (k > 0 && l < 1 && d == "d")
                {
                    for (int i = 0; i <= Battleships.Peek(); i++)
                    {
                        if (pos[k - 1, l] == 1 ||
                            pos[k - 1, l + i] == 1 ||
                            pos[k, l + 1] == 1 ||
                            pos[k + i,l] == 1 ||
                            pos[k + i,l + 1] == 1)
                        {
                            return false;
                        }
                    }
                }

                if (k > 0 && l > 0 && d == "r")
                {
                    for (int i = 0; i <= Battleships.Peek(); i++)
                    {
                        if (pos[k,l] == 1 ||
                            pos[k,l - 1] == 1 ||
                            pos[k - 1,l - 1] == 1 ||
                            pos[k + 1,l - 1] == 1 ||
                            pos[k + 1,l] == 1 ||
                            pos[k + 1,l + i] == 1 ||
                            pos[k,l + i] == 1 ||
                            pos[k + 1,l + i] == 1 ||
                            pos[k - 1,l + i] == 1
                            )
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        #endregion

        public static void Shoot(int k, int l)
        {
            int i = pos[k, l];

            if(i == 1)
            {
                pos[k, l] = 2;
                hitCountP++;
            }
        }
    }
}