using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day04 : IDay
    {
        public static void Solve1()
        {
            Shared.WriteHeader("Day 04 (part 1)");

            var lines = File.ReadAllLines("Data/Day04.txt");

            int sizeX = lines[0].Length;
            int sizeY = lines.Length;

            bool[,] map = new bool[sizeX, sizeY];

            for (int y = 0; y <sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    map[x, y] = lines[y][x] == '@';
                }
            }

            int result = 0;

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    int count = 0;

                    if (lines[y][x] != '@')
                        continue;

                    for (int dx = -1; dx < 2; dx++)
                    {
                        for (int dy = -1; dy < 2; dy++)
                        {
                            if (dx == 0 && dy == 0)
                                continue;

                            if (x + dx < 0 || x + dx >= sizeX)
                                continue;

                            if (y + dy < 0 || y + dy >= sizeY)
                                continue;

                            if (map[x + dx, y + dy])
                                count++;

                        }
                    }

                    if (count < 4)
                        result++;
                        
                }
            }

            Console.WriteLine($"Result: {result}");
        }

        public static void Solve2()
        {
            Shared.WriteHeader("Day 04 (part 2)");

            var lines = File.ReadAllLines("Data/Day04.txt");

            int sizeX = lines[0].Length;
            int sizeY = lines.Length;

            bool[,] map = new bool[sizeX, sizeY];

            int result = 0;
            int lastResult = 0;

            while (true)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        map[x, y] = lines[y][x] == '@';
                    }
                }

                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        int count = 0;

                        if (lines[y][x] != '@')
                            continue;

                        for (int dx = -1; dx < 2; dx++)
                        {
                            for (int dy = -1; dy < 2; dy++)
                            {
                                if (dx == 0 && dy == 0)
                                    continue;

                                if (x + dx < 0 || x + dx >= sizeX)
                                    continue;

                                if (y + dy < 0 || y + dy >= sizeY)
                                    continue;

                                if (map[x + dx, y + dy])
                                    count++;

                            }
                        }

                        if (count < 4)
                        {
                            result++;
                            char[] tmp = lines[y].ToArray();
                            tmp[x] = 'x';
                            lines[y] = new string(tmp);
                        }
                            

                    }
                }

                if (lastResult == result)
                    break;

                lastResult = result;
            }

            

            Console.WriteLine($"Result: {result}");
        }
    }
}
