using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day07 : IDay
    {
        public static void Solve1()
        {
            Shared.WriteHeader("Day 07 (part 1)");

            var lines = File.ReadAllLines("Data/Day07.txt");

            int result = 0;


            for (int i = 0; i < lines.Length-1; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == 'S' || lines[i][j] == '|')
                    {
                        char[] nextLine = lines[i+1].ToArray();

                        if (nextLine[j] == '.')
                            nextLine[j] = '|';
                        else if (nextLine[j] == '^')
                        {
                            nextLine[j - 1] = '|';
                            nextLine[j + 1] = '|';
                            result++;
                        }

                        lines[i + 1] = new string(nextLine);
                    }
                }    
            }

            Console.WriteLine($"Result {result}");
        }

        public static void Solve2()
        {
            Shared.WriteHeader("Day 07 (part 2)");

            var lines = File.ReadAllLines("Data/Day07.txt");

            long result = 0;


            int width = lines[0].Length;
            int height = (lines.Length / 2) - 1;

            long[,] table = new long[width, height];

            for (int i = 2;i < lines.Length;i += 2)
            {
                int pos = (i / 2) - 1;

                for (int j = 0; j < lines[0].Length; j++)
                {
                    if (lines[i][j] == '^')
                        table[j, pos] = -1;
                }
            }


            for (int y = height-1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    if (table[x, y] != -1)
                        continue;

                    long left = table[x - 1, y];
                    long right = table[x + 1, y];

                    if (left == 0)
                        left = 1;

                    if (right == 0)
                        right = 1;

                    if (y == 0)
                    {
                        result = left+right; 
                        break;
                    }

                    int py = 0;

                    while (true)
                    {
                        py--;

                        if (y + py < 0 || table[x, y + py] == -1)
                            break;

                        if (table[x - 1, y + py] == -1 || table[x + 1, y + py] == -1)
                            table[x, y + py] = left + right;
                    }
                }
            }


            Console.WriteLine($"Result {result}");
        }
    }
}
