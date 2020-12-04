using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc2020
{
    public static class DayFour
    {
        public static void RunPartOne()
        {
            int validPassportCount = 0;
            List<string> currentPassport = new List<string>();
            List<List<string>> AllPassports = new List<List<string>>();

            var data = File.ReadAllLines("DayFourData.txt");
            int passportCount = (from s in data where string.IsNullOrEmpty(s) select s).Count();
            Console.WriteLine($"Passport count: {passportCount}");

            foreach (var line in data)
            {
                //Console.WriteLine(line);
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    AllPassports.Add(currentPassport);
                    if (isValidPassport(currentPassport)) validPassportCount++;

                    currentPassport.Clear();
                    continue;
                }
                else
                {
                    currentPassport.Add(line);
                }
            }

            Console.WriteLine($"Total Passports processed: {AllPassports.Count}");
            Console.WriteLine($"Valid Passports:  {validPassportCount}");
        }

        public static void RunPartTwo()
        {
            int validPassportCount = 0;
            List<string> currentPassport = new List<string>();
            List<List<string>> AllPassports = new List<List<string>>();

            var data = File.ReadAllLines("DayFourData.txt");
            int passportCount = (from s in data where string.IsNullOrEmpty(s) select s).Count();
            Console.WriteLine($"Passport count: {passportCount}");

            foreach (var line in data)
            {
                //Console.WriteLine(line);
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    AllPassports.Add(currentPassport);
                    if (isValidPassportData(currentPassport)) validPassportCount++;

                    currentPassport.Clear();
                    continue;
                }
                else
                {
                    currentPassport.Add(line);
                }
            }

            Console.WriteLine($"Total Passports processed: {AllPassports.Count}");
            Console.WriteLine($"Valid Passports:  {validPassportCount}");
        }

        private static bool isValidPassportData(List<string> currentPassport)
        {
            /*  byr (Birth Year) - four digits; at least 1920 and at most 2002.
                iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                hgt (Height) - a number followed by either cm or in:
                If cm, the number must be at least 150 and at most 193.
                If in, the number must be at least 59 and at most 76.
                hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                pid (Passport ID) - a nine-digit number, including leading zeroes.
                cid (Country ID) - ignored, missing or not. */
            if (isValidPassport(currentPassport))
            {
                /* validate data */
                List<string> parsed = new List<string>();
                foreach (string part in currentPassport)
                {
                    parsed.AddRange(part.Split(' '));
                }

                Dictionary<string, string> passport = new Dictionary<string, string>();
                foreach (var field in parsed)
                {
                    var key = field.Split(':')[0];
                    var val = field.Split(':')[1];
                    passport.Add(key, val);
                }

                //byr (Birth Year) - four digits; at least 1920 and at most 2002.
                var birthYear = int.Parse(passport["byr"]);
                if (birthYear < 1920 || birthYear > 2002) return false;
                //iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                var issYear = int.Parse(passport["iyr"]);
                if (issYear < 2010 || issYear > 2020) return false;
                //eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                var expYear = int.Parse(passport["eyr"]);
                if (expYear < 2020 || expYear > 2030) return false;
                //hgt (Height) - a number followed by either cm or in:
                if (!isHeightValid(passport["hgt"])) return false;
                //hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                var pattern = "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";
                Regex r = new Regex(pattern);
                if (!r.IsMatch(passport["hcl"])) return false;
                //ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                List<String> validEyeColors = new List<String>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                if (!validEyeColors.Contains(passport["ecl"])) return false;
                //pid (Passport ID) - a nine-digit number, including leading zeroes.
                var pidPattern = "^[0-9]{9}$";
                Regex rPid = new Regex(pidPattern);
                if (!rPid.IsMatch(passport["pid"])) return false;

                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool isHeightValid(string v)
        {
            /*If cm, the number must be at least 150 and at most 193.
              If in, the number must be at least 59 and at most 76. */
            if (v.IndexOf("cm") > 0)
            {
                var height = int.Parse(v.Replace("cm", ""));
                if (height < 150 || height > 193) return false;
            }
            else if (v.IndexOf("in") > 0)
            {
                var height = int.Parse(v.Replace("in", ""));
                if (height < 59 || height > 76) return false;
            }
            else
            {
                return false;
            }
            return true;
        }

        private static bool isValidPassport(List<string> currentPassport)
        {
            /*  byr (Birth Year)
                iyr (Issue Year)
                eyr (Expiration Year)
                hgt (Height)
                hcl (Hair Color)
                ecl (Eye Color)
                pid (Passport ID)
                cid (Country ID) */
            List<string> validFields = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };

            List<string> passport = new List<string>();
            foreach (string part in currentPassport)
            {
                passport.AddRange(part.Split(' '));
            }

            Dictionary<string, string> fields = new Dictionary<string, string>();
            foreach (var field in passport)
            {
                var key = field.Split(':')[0];
                var val = field.Split(':')[1];
                if (!fields.ContainsKey(key))
                {
                    fields.Add(key, val);
                }
            }

            foreach (var validField in validFields)
            {
                if (!fields.ContainsKey(validField) && validField != "cid")
                {
                    return false;
                }
            }
            return true;
        }
    }
}