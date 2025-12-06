using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day06 : IDay
    {
        public static void Solve1()
        {
            Shared.WriteHeader("Day 06 (part 1)");

            var lines = File.ReadAllLines("Data/Day06.txt");

            long result = 0;

            List<int> columnWidth = new List<int>();

            string opLine = lines[lines.Length - 1];
            for (int i = 0; i < lines[0].Length; i++)
            {
                if (opLine[i] == '+' || opLine[i] == '*')
                    columnWidth.Add(0);

                columnWidth[columnWidth.Count - 1]++;
            }

            int columnCount = columnWidth.Count;

            for (int i = 0; i < columnCount - 1; i++)
                columnWidth[i]--;

            List<string>[] columns = new List<string>[columnCount];

            for (int i = 0; i < columnCount; i++)
                columns[i] = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                int pos = 0;
                for (int j = 0; j < columnCount; j++)
                {
                    columns[j].Add(lines[i].Substring(pos, columnWidth[j]));
                    pos += columnWidth[j];
                    pos += 1;
                }
            }

            for (int i = 0; i < columnCount; i++)
            {
                long colRes = 0;
                bool colOp = columns[i][lines.Length - 1].Trim() == "+";

                for (int j = 0;j < columns[i].Count-1; j++)
                {
                    if (j == 0)
                        colRes = long.Parse(columns[i][j]);
                    else if (colOp)
                        colRes += long.Parse(columns[i][j]);
                    else
                        colRes *= long.Parse(columns[i][j]);
                }

                result += colRes;
            }

            Console.WriteLine($"Result {result}");
        }

        public static void Solve2()
        {
            Shared.WriteHeader("Day 06 (part 2)");

            var lines = File.ReadAllLines("Data/Day06.txt");

            long result = 0;

            List<int> columnWidth = new List<int>();

            string opLine = lines[lines.Length - 1];
            for (int i = 0; i < lines[0].Length; i++)
            {
                if (opLine[i] == '+' || opLine[i] == '*')
                    columnWidth.Add(0);

                columnWidth[columnWidth.Count - 1]++;
            }

            int columnCount = columnWidth.Count;

            for (int i = 0; i < columnCount - 1; i++)
                columnWidth[i]--;

            List<string>[] columns = new List<string>[columnCount];

            for (int i = 0; i < columnCount; i++)
                columns[i] = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                int pos = 0;
                for (int j = 0; j < columnCount; j++)
                {
                    columns[j].Add(lines[i].Substring(pos, columnWidth[j]));
                    pos += columnWidth[j];
                    pos += 1;
                }
            }

            for (int i = 0; i < columnCount; i++)
            {
                long colRes = 0;
                bool colOp = columns[i][lines.Length - 1].Trim() == "+";

                for (int j = 0; j < columnWidth[i]; j++)
                {
                    string numString = "";

                    for (int k = 0; k < columns[i].Count-1; k++)
                    {
                        numString += columns[i][k][j];
                    }

                    if (j == 0)
                        colRes = long.Parse(numString);
                    else if (colOp)
                        colRes += long.Parse(numString);
                    else
                        colRes *= long.Parse(numString);
                }

                result += colRes;
            }

            Console.WriteLine($"Result {result}");
        }
    }
}
