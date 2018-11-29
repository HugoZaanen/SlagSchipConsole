using System;

namespace zeeeeeeeeeeeeeee
{
    class Program
    {
        const int width = 10;
        const int height = 10;

        static int[,] board = new int[width, height];


        static void Main(string[] args)
        {
            Console.WriteLine(Place(5, 5, 5, 5, "d"));


            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    Console.Write(board[x, y]);
                }
                Console.WriteLine();
            }


            Console.ReadLine();
        }



        static bool Place(int x, int y, int boat, int length, string dir)
        {
            int right = Convert.ToInt32(dir.ToLower() == "r");
            int down = Convert.ToInt32(dir.ToLower() == "d");

            //Handige inline functie
            bool Check(int ix, int iy)
            {
                return (ix >= 0 && ix < width && iy >= 0 && iy < height);
            }

            //Check of het mag
            for (int i = 0; i < length; ++i)
            {
                if (!Check(x + (i * right), y + (i * down)) || board[x + (i * right), y + (i * down)] > 0)
                {
                    return false;
                }
            }

            //Plaat het (haal deze weg als je alleen wil checken)
            for (int i = 0; i < length; ++i)
            {
                board[x + (i * right), y + (i * down)] = boat;
            }

            return true;
        }
    }
}
