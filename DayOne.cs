using System;
using System.IO;

namespace aoc2020
{
    public static class DayOne
    {
        public static void RunPartOne()
        {
            int product = 0;
            var data = File.ReadAllLines("DayOneData.txt");

            foreach (var lineA in data)
            {
                var a = int.Parse(lineA);
                foreach (var lineB in data)
                {
                    var b = int.Parse(lineB);
                    Console.WriteLine($"a: {a}, b: {b}");
                    var sum = a + b;
                    if (sum == 2020)
                    {
                        product = a * b;
                        Console.WriteLine($"This is it!!! {product}");
                        break;
                    }
                }
                if (product != 0) break;
            }
        }

        public static void RunPartTwo()
        {
            int product = 0;
            var data = File.ReadAllLines("DayOneData.txt");

            foreach (var lineA in data)
            {
                var a = int.Parse(lineA);
                foreach (var lineB in data)
                {
                    var b = int.Parse(lineB);
                    foreach (var lineC in data)
                    {
                        var c = int.Parse(lineC);
                        Console.WriteLine($"a: {a}, b: {b}, c:{c}");
                        var sum = a + b + c;
                        if (sum == 2020)
                        {
                            product = a * b * c;
                            Console.WriteLine($"This is it!!! {product}");
                            break;
                        }
                    }

                }
                if (product != 0) break;
            }
        }
    }
}