using System;
using System.Collections.Generic;
using System.IO;

namespace aoc2020
{
    public static class DayThree
    {
        public static void RunPartOne()
        {
            int treeCount = GetTreeCount(3, 1);
            Console.WriteLine($"Tree count for (3,1) = {treeCount}");
        }

        private static int GetTreeCount(int right, int down)
        {
            Console.WriteLine($"*** Processing ({right},{down}) ***");
            int currentColumn = 0;
            int treeCount = 0;

            var data = File.ReadAllLines("DayThreeData.txt");
            int bottomOfHill = data.Length - 1;
            int lineLength = data[0].Length - 1;

            for (var currentLine = 0; currentLine < data.Length; currentLine++)
            {
                if (currentLine + down > bottomOfHill) break;

                currentColumn += right;
                if (currentColumn > lineLength)
                {
                    //Console.WriteLine($"End of line {currentColumn}");
                    currentColumn = (currentColumn - lineLength - 1);
                    //Console.WriteLine($"Wrap to {currentColumn}");
                }
                var posA = data[currentLine][currentColumn];
                var endPos = data[currentLine + down][currentColumn];

                //Console.WriteLine($"currentLine {currentLine + 1} and currentColumn {currentColumn} and lineLength = {lineLength}");
                if (endPos == '#')
                {
                    treeCount++;
                }
                if (down > 1)
                {
                    currentLine++;
                }
            }
            return treeCount;
        }

        public static void RunPartTwo()
        {
            /*
            Right 1, down 1.
            Right 3, down 1. (This is the slope you already checked.)
            Right 5, down 1.
            Right 7, down 1.
            Right 1, down 2.
            */
            var data = "1,1|3,1|5,1|7,1|1,2";
            var paths = data.Split('|');
            Int64 product = 1;
            var results = new List<int>();

            foreach (var xy in paths)
            {
                var x = int.Parse(xy.Split(',')[0]);
                var y = int.Parse(xy.Split(',')[1]);

                int treeCount = GetTreeCount(x, y);
                Console.WriteLine($"Tree count for ({x},{y}) = {treeCount}");
                results.Add(treeCount);
            }

            product = results[0];
            foreach (var factor in results)
            {
                if (factor != results[0])
                    product = product * factor;
            }
            Console.WriteLine($"Product of tree count = {product}");
        }


    }

}