using System;
using System.Collections.Generic;

namespace SlagSchipConsole
{
    public class Game
    {
        public static int[,] pos;
        public static Stack<int> Battleships = new Stack<int>();

        
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

            pos = initializeArray();

            SetPos(5,3,"d");
            SetPos(0,3,"d");
            SetPos(0,0,"d");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(pos[i, j] + " ");
                }
                Console.WriteLine("");
            }

            //loops(9,4,"r");
            
        }

        public static int[,] initializeArray()
        {
            int[,] positions = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    positions[i, j] = 0;
                }
            }

            return positions;
        }

        public static void SetPos(int k, int l, string m)
        {
            if (loops(k,l,m))
            {
                if(m == "r")
                {
                    for (int i = 0;i < Battleships.Peek();i++)
                    {
                        pos[k, l + i] = 1;
                    }
                }
                else
                {
                    for (int i = 0;i < Battleships.Peek();i++)
                    {
                        pos[k + i, l] = 1;
                    }
                }
                Battleships.Pop();
            }
        }

        public static bool loops(int k, int l, string m)
        {
            if (l > 0 && l < 9 && m == "d")
            {
                if (!(Battleships.Peek() + k >= 10))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (pos[i, l - 1] == 1)
                        {
                            return false;
                        }

                        if (pos[i, l + 1] == 1)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (l < 1 && m == "d")
            {
                if (!(Battleships.Peek() + k >= 10))
                {
                    for (int i = 0; i < Battleships.Peek(); i++)
                    {                       
                        if (pos[i, l + 1] == 1)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else if(m == "d")
            {
                if (!(Battleships.Peek() + k >= 10))
                {
                    for (int i = 0; i < Battleships.Peek(); i++)
                    {
                        if (pos[k + i, l - 1] == 1)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            if (k > 0 && k < 9 && m == "r")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (pos[k + 1,l + i] == 1)
                    {
                        return false;
                    }

                    if (pos[k - 1, l + i] == 1)
                    {
                        return false;
                    }
                }
            }
            else if (k < 1 && m == "r")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (pos[k + 1, l + i] == 1)
                    {
                        return false;
                    }
                }
            }
            else if(m == "r")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (pos[k - 1,l + i] == 1)
                    {
                        return false;
                    }                    
                }
            }
            return true;
        }
    }
}