using System;
using System.Collections.Generic;
using lab7_2017.Properties;

namespace lab7_2017
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Select starting field:\n" +
                              "[0] Random (need input)\n" +
                              "[1] Glider\n" +
                              "[2] Middleweight Spaceship\n" +
                              "[3] Glider Generator\n" +
                              "[4] Prepulsar\n" +
                              "[5] Unix\n" +
                              "[6] Pi Portraitor");
            Console.Write("Select: ");
            int choice = Int32.Parse(Console.ReadLine());

            Life l = null;
            switch (choice)
            {
                case 1: l = new Life(Sample.Glider); break;
                case 2: l = new Life(Sample.MiddleweightSpaceship); break;
                case 3: l = new Life(Sample.GliderGenerator); break;
                case 4: l = new Life(Sample.Prepulsar); break;
                case 5: l = new Life(Sample.Unix); break;
                case 6: l = new Life(Sample.PiPortraitor); break;
                default: break;
            }
            if (l == null)
            {
                Console.Write("Input width and height (example: 4 4): ");
                string[] mass = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                l = new Life(Int32.Parse(mass[0]), Int32.Parse(mass[1]));
            }
            Console.Clear();
            l.run();
        }
    }
}