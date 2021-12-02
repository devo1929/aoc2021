using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Days
{
    public class Day2 : AbstractDay
    {
        private const string _commandRegex = @"^(forward|up|down)\s+(\d+)$";

        protected override void Puzzle1()
        {
            var commands = GetInput().Select(ToCommand).ToList();

            var horizontalPosition = 0;
            var depth = 0;
            foreach (var command in commands)
            {
                switch (command.Direction)
                {
                    case Direction.forward:
                        horizontalPosition += command.Value;
                        break;
                    case Direction.up:
                        depth -= command.Value;
                        break;
                    case Direction.down:
                        depth += command.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var plannedCourse = horizontalPosition * depth;

            Console.WriteLine($"Planned course: {plannedCourse}");
        }

        protected override void Puzzle2()
        {
            var commands = GetInput().Select(ToCommand).ToList();
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;
            
            foreach (var command in commands)
            {
                switch (command.Direction)
                {
                    case Direction.forward:
                        horizontalPosition += command.Value;
                        depth += aim * command.Value;
                        break;
                    case Direction.up:
                        aim -= command.Value;
                        break;
                    case Direction.down:
                        aim += command.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var plannedCourse = horizontalPosition * depth;

            Console.WriteLine($"Planned course: {plannedCourse}");
        }

        private static Command ToCommand(string input)
        {
            var match = Regex.Match(input, _commandRegex);
            if (!match.Success)
                throw new Exception("Invalid input");

            return new Command()
            {
                Direction = Enum.Parse<Direction>(match.Groups[1].Value),
                Value = int.Parse(match.Groups[2].Value)
            };
        }

        private class Command
        {
            public Direction Direction { get; set; }
            public int Value { get; set; }

            public override string ToString() => $"{Direction} {Value}";
        }

        private enum Direction
        {
            forward = 1,
            up = 2,
            down = 3
        }
    }
}