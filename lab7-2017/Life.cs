using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace lab7_2017
{
    public class Life
    {
        private int OX;
        private int OY;
        private byte[,] a;

        private const ConsoleColor ALIVE_COLOR = ConsoleColor.White;
        private const ConsoleColor DIED_COLOR = ConsoleColor.Black;
        
        public Life(int width, int height)
        {
            OX = width;
            OY = height;
            a = new byte[OY, OX];
            Random r = new Random();
            for (int i = 0; i < OY; i++)
            for (int j = 0; j < OX; j++)
                a[i, j] = (byte)(r.Next() % 5 == 0 ? 1 : 0);
        }

        public Life(int width, int height, byte chance)
        {
            OX = width;
            OY = height;
            a = new byte[OY, OX];
            Random r = new Random();
            for (int i = 0; i < OY; i++)
            for (int j = 0; j < OX; j++)
                a[i, j] = (byte)(r.Next() % chance == 0 ? 1 : 0);
        }

        public Life(byte[,] array)
        {
            OY = array.GetLength(0);
            OX = array.GetLength(1);
            a = array;
        }

        public void DebugIt()
        {
            Console.WriteLine("OX (width): " + OX);
            Console.WriteLine("OY (height): " + OY);
            for (int i = 0; i < OY; i++)
            {
                for (int j = 0; j < OX; j++)
                    Console.Write(a[i,j] + " ");
                Console.WriteLine();
            }
        }

        public int correctData(int num, int size)
        {
            if (num >= size)
                return 0;
            if (num < 0)
                return size - 1;
            return num;
        }

        private byte getA(int y, int x)
        {
            int my = correctData(y, OY);
            int mx = correctData(x, OX);
            byte ans = a[my, mx];
            return ans;
        }

        private byte sumAliveAround(int y, int x)
        {
            return (byte) (getA(y - 1, x - 1) + getA(y, x - 1) + getA(y + 1, x - 1) +
                           getA(y - 1, x) + getA(y + 1, x) +
                           getA(y - 1, x + 1) + getA(y, x + 1) + getA(y + 1, x + 1));
        }

        private bool isAlive(int y, int x)
        {
            if (getA(y, x) == 1)
            {
                int sum = sumAliveAround(y, x);
                return sum == 2 || sum == 3 ? true : false; //for alive
            }
            else
                return sumAliveAround(y, x) == 3 ? true : false; //for dead
        }

        public void oneStep()
        {
            byte[,] h = new byte[OY, OX];
            for (int i = 0; i < OY; i++)
            for (int j = 0; j < OX; j++)
                h[i, j] = (byte) (isAlive(i, j) ? 1 : 0);
            a = h;
            return;
        }

        private void print()
        {
            for (int i = 0; i < OY; i++)
            {
                for (int j = 0; j < OX; j++)
                    Console.Write(a[i, j] == 1 ? " o " : "   ");
                Console.WriteLine();
            }
        }
        
        public void run()
        {
            while (true)
            {
                Console.Clear();
                print();
                Thread.Sleep(300);
                oneStep();
            }
        
        }
    }
}