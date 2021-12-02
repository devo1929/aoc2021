using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Days
{
    public abstract class AbstractDay
    {
        public void Run()
        {
            Puzzle1();
            Puzzle2();
        }

        private IEnumerable<string> _GetInput(string file = "input") => File
            .ReadAllLines($"data/{GetType().Name.ToLower()}/{file}.txt")
            .Where(l => !string.IsNullOrWhiteSpace(l));

        protected IEnumerable<string> GetInput() => _GetInput();

        protected IEnumerable<string> GetExampleInput() => _GetInput("input.example");

        protected abstract void Puzzle1();

        protected abstract void Puzzle2();
    }
}