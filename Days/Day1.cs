using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Days
{
    public class Day1 : AbstractDay
    {
        protected override void Puzzle1()
        {
            var input = GetInput().Select(int.Parse).ToList();

            var increaseCount = GetIncreaseCount(input);

            Console.WriteLine($"Increase count: {increaseCount}");
        }

        protected override void Puzzle2()
        {
            var input = GetInput().Select(int.Parse).ToList();
            input = CreateWindows(input, 3);

            var increaseCount = GetIncreaseCount(input);

            Console.WriteLine($"Increase count: {increaseCount}");
        }

        private static List<int> CreateWindows(List<int> input, int windowSize)
        {
            var windowSums = new List<int>();
            for (var i = 0; i < input.Count; i++)
            {
                var _windowSize = Math.Min(windowSize, input.Count - i);
                var window = input.GetRange(i, _windowSize);
                windowSums.Add(window.Sum());
            }

            return windowSums;
        }

        private static int GetIncreaseCount(List<int> input)
        {
            var increaseCount = 0;
            var last = (int?)null;
            foreach (var current in input)
            {
                if (last < current)
                    increaseCount++;

                last = current;
            }

            return increaseCount;
        }
    }
}