using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlagSchipConsole
{
    public class GameLogic
    {
        private static bool done;

        public static void CheckPosition(int[,] board, int xpos, int ypos)
        {
            xpos--;
            ypos--;
            for (int x = xpos; x < xpos + 3; x++)
            {

                for (int y = ypos; y < ypos + 3; y++)
                {

                    if (OutOfBound(x))
                    {
                        continue;
                    }

                    if (OutOfBound(y))
                    {
                        continue;
                    }

                    if (board[x, y] == 1)
                    {
                        done = true;
                        return;
                    }
                }
            }
        }

        public static bool CheckShipPositions(int[,] board, int x, int y, string direction, int shipsize)
        {

            if (direction == "d")
            {
                for (int i = 0; i < shipsize; i++)
                {
                    if (OutOfBound(x))
                    {
                        return false;
                    }
                    CheckPosition(board, x, y);
                    x = x + 1;
                }
                if (done)
                {
                    return false;
                }
            }
            else
            {
                for (int i = 0; i < shipsize; i++)
                {
                    if (OutOfBound(y))
                    {
                        return false;
                    }
                    CheckPosition(board, x, y);
                    y = y + 1;
                }
                if (done)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool OutOfBound(int num)
        {
            if (num > 9 || num < 0)
            {
                return true;
            }
            return false;
        }
    }
}