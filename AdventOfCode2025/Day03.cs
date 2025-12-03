using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day03 : IDay
    {
        public static void Solve1()
        {
            Shared.WriteHeader("Day 03 (part 1)");

            var lines = File.ReadAllLines("Data/Day03.txt");

            int result = 0;

            foreach (var line in lines)
            {
                char max1 = line[0];
                char max2 = line[line.Length - 1];

                for (int i = 1; i < line.Length-1; i++)
                {
                    if (line[i] > max1)
                    {
                        max1 = line[i];
                        max2 = line[line.Length - 1];
                    }
                    else if (line[i] > max2)
                    {
                        max2 = line[i];
                    }
                }

                result += int.Parse(max1 + "" + max2);
            }

            Console.WriteLine($"Result: {result}");
        }

        public static void Solve2()
        {
            Shared.WriteHeader("Day 03 (part 2)");

            var lines = File.ReadAllLines("Data/Day03.txt");

            long result = 0;

            foreach (var line in lines)
            {
                int lineLen = line.Length;

                string find(int left, int pos)
                {
                    if (left == 0)
                        return "";

                    int charsLeft = lineLen - pos - left+1;

                    int best = pos;

                    for (int i = pos; i < pos + charsLeft; i++)
                    {
                        if (line[i] > line[best])
                            best = i;
                    }

                    return line[best].ToString() + find(left - 1, best + 1);
                }

                string res = find(12, 0);
                result += long.Parse(res);
            }


            Console.WriteLine($"Result: {result}");
        }
    }
}
