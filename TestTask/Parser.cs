using System;
using System.Linq;

namespace TestTask
{
    public class Parser
    {
        private readonly string[] _lines;

        public Parser(string[] lines)
        {
            _lines = lines ?? throw new ArgumentNullException(nameof(lines),
                "Lines cannot be null");
        }

        public int[] ParsedIntegers()
        {
            int[] result = new int[_lines.Length];

            for (int i = 0; i < _lines.Length; i++)
            {
                string[] stringNums = _lines[i].Split();

                if (stringNums.Length == 0) continue;

                result[i] = ParseLine(stringNums);
            }

            return result;
        }

        private int ParseLine(string[] numStrings)
        {
            int[] numbers = new int[numStrings.Length];

            for (int i = 0; i < numStrings.Length; i++)
            {
                numbers[i] = int.Parse(numStrings[i]);
            }

            return HandleNumbers(numbers);
        }

        private int HandleNumbers(int[] numbers)
        {
            var type = (HandleType)numbers[0];
            var parameters = numbers.Skip(1);
            int result = type switch
            {
                HandleType.Type1 => parameters.Sum() % 255,
                HandleType.Type2 => parameters.Aggregate((x, y) => x * y) % 255,
                HandleType.Type3 => parameters.Max(),
                HandleType.Type4 => parameters.Min(),
                _ => throw new Exception("Undefined HandleType")
            };
            return result;
        }
    }
}
