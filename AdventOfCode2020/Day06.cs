using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    class Day06
    {
        static void Main(string[] args)
        {
            string inputFile = File.ReadAllText(@"input\day06.txt");
            List<string> input = new List<string>(inputFile.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            Console.WriteLine($"Sum of any yesses: {GetSumAnyYes(input)}");

            Console.WriteLine($"Sum of all yesses: {GetSumAllYes(input)}"); ;
        }

        static int GetGroupTotal(string group)
        {
            string clean = group.Replace("\n", "").Replace("\r", "");
            char[] answers = clean.Distinct().ToArray();

            return answers.Length;
        }

        private static int GetSumAnyYes(List<string> input)
        {
            int total = 0;
            foreach(var group in input)
            {
                total += GetGroupTotal(group);
            }
            return total;
        }

        private static int GetSumAllYes(List<string> input)
        {
            int totalYesAnswers = 0;

            foreach (var group in input)
            {
                string[] groupForms = group.Split('\n');
                Array.Sort(groupForms, (x, y) => x.Length.CompareTo(y.Length));

                // remove carriage returns
                for (int i = 0; i < groupForms.Length; i++)
                {
                    if (groupForms[i].Contains('\r'))
                    {
                        groupForms[i] = groupForms[i].TrimEnd('\r');
                    }
                }

                foreach (var answer in groupForms[0])
                {
                    int sameAnswer = 0;
                    foreach (var form in groupForms)
                    {
                        if (form.Contains(answer))
                        {
                            sameAnswer++ ;
                        }
                        else
                        {
                            sameAnswer = 0;
                        }
                    }

                    if(sameAnswer == groupForms.Count())
                    {
                        totalYesAnswers++;
                    }
                }
            }

            return totalYesAnswers;
        }
    }
}
