using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Shared
    {
        public static void WriteHeader(string text)
        {
            Console.WriteLine();
            Console.WriteLine(@"/----------------------------------\");
            Console.Write(@"|");

            for (int i = 0; i < (34-text.Length)/2; i++)
                Console.Write(" ");

            Console.Write(text);

            for (int i = 0; i < Math.Ceiling((34.0 - text.Length) / 2); i++)
                Console.Write(" ");


            Console.WriteLine(@"|");
            Console.WriteLine(@"\----------------------------------/");
            Console.WriteLine();
        }

        public static void Time(Action a)
        {
            Stopwatch sw = Stopwatch.StartNew();
            a.Invoke();
            sw.Stop();
            Console.WriteLine($"Took: {sw.ElapsedMilliseconds}ms");
        }
    }
}
