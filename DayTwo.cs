using System;
using System.IO;

namespace aoc2020
{
    public static class DayTwo
    {
        public static void RunPartOne()
        {
            int validPasswordCount = 0;
            var data = File.ReadAllLines("DayTwoData.txt");

            foreach (var line in data)
            {
                var pwString = line.Split(' ');
                var pwCountRange = pwString[0];
                var startRange = int.Parse(pwCountRange.Split('-')[0]);
                var endRange = int.Parse(pwCountRange.Split('-')[1]);
                var pwLetter = pwString[1].Replace(":", "");
                var pw = pwString[2];

                int letterCount = GetLetterCount(pwLetter, pw);

                if (letterCount >= startRange && letterCount <= endRange)
                {
                    validPasswordCount++;
                }
            }
            Console.WriteLine($"Valid passwords found: {validPasswordCount}");
        }

        private static int GetLetterCount(string pwLetter, string pw)
        {
            int letterCount = 0;
            char letterToCount = pwLetter.ToCharArray()[0];
            foreach (char letter in pw)
            {
                if (letter == letterToCount)
                {
                    letterCount++;
                }
            }
            return letterCount;
        }

        public static void RunPartTwo()
        {
            int validPasswordCount = 0;
            var data = File.ReadAllLines("DayTwoData.txt");

            foreach (var line in data)
            {
                var pwString = line.Split(' ');
                var pwCountRange = pwString[0];
                var startRange = int.Parse(pwCountRange.Split('-')[0]);
                var endRange = int.Parse(pwCountRange.Split('-')[1]);
                var pwLetter = pwString[1].Replace(":", "");
                var pw = pwString[2];

                int letterCount = GetLetterCount(pwLetter, pw);

                if (isValidPassword(pw, pwLetter, startRange, endRange))
                {
                    validPasswordCount++;
                }
            }
            Console.WriteLine($"Valid passwords found: {validPasswordCount}");
        }

        private static bool isValidPassword(string pw, string pwLetter, int startRange, int endRange)
        {
            bool isStartValid = false;
            bool isEndValid = false;
            char letterToTest = pwLetter.ToCharArray()[0];

            isStartValid = pw[startRange - 1] == letterToTest;
            isEndValid = pw[endRange - 1] == letterToTest;

            return (isStartValid || isEndValid) && !(isStartValid && isEndValid);
        }
    }

}