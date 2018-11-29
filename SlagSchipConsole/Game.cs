using System;
using System.Collections.Generic;


namespace SlagSchipConsole
{
    public class Game
    {
        public static int[,] pos = 
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}
        };

        public static Stack<int> Battleships = new Stack<int>();
        public static int x = -1;
        public static int y = -1;
        public static string dir;
        public static int count;

        public static void PlayBattleShip()
        {
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
            

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(pos[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();

            SetShip(3,0,"d");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(pos[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

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

                Battleships.Peek();
            }
        }

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
    }
}