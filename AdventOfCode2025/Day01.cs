using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day01
    {
        public static void Solve1()
        {
            Console.WriteLine();
            Console.WriteLine(@"/----------------------------------\");
            Console.WriteLine(@"|         Day 01 (part 1)          |");
            Console.WriteLine(@"\----------------------------------/");
            Console.WriteLine();


            string[] data1 = File.ReadAllLines("Data/Day01_1.txt");

            int wheel = 50;
            int zeroCount = 0;

            foreach (var line in data1)
            {
                int number = int.Parse(line[1..]);

                if (line[0] == 'L')
                    wheel -= number;
                else
                    wheel += number;

                wheel = (wheel + 100) % 100;
                if (wheel == 0)
                    zeroCount++;
            }

            Console.WriteLine($"Password: {zeroCount}");

        }

        public static void Solve2()
        {
            Console.WriteLine();
            Console.WriteLine(@"/----------------------------------\");
            Console.WriteLine(@"|         Day 01 (part 2)          |");
            Console.WriteLine(@"\----------------------------------/");
            Console.WriteLine();


            string[] data1 = File.ReadAllLines("Data/Day01_1.txt");

            int wheel = 50;
            int zeroCount = 0;

            foreach (var line in data1)
            {
                int number = int.Parse(line[1..]);

                for (int i = 0; i < number; i++)
                {
                    if (line[0] == 'L')
                        wheel--;
                    else
                        wheel++;

                    wheel = (wheel + 100) % 100;

                    if (wheel == 0)
                        zeroCount++;
                }
            }

            Console.WriteLine($"Password: {zeroCount}");

        }
    }
}
