using System;

namespace TestTask
{
    public class MovingAverage
    {
        private readonly int[] _input;
        private int _window;
        private int _minWindow = 3;
        private int _maxWindow = 1000001;

        public MovingAverage(int[] input, int window)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input), 
                "Input cannot be null");

            if (window < _minWindow || window > _maxWindow
                || window % 2 == 0)
                throw new ArgumentException(nameof(window),
                    "Incorrect value of window parameter");

            _window = window;
        }

        //https://habr.com/ru/post/134375/
        public double[] Smooth()
        {
            int n = _input.Length;
            double[] result = new double[n];
            if (_window % 2 == 0)
            {
                _window++;
            }
            int hw = (_window - 1) / 2;

            result[0] = _input[0];

            int k1;
            int k2;
            int z;
            float tmp;

            for (int i = 1; i < n; i++)
            {
                tmp = 0;
                if (i < hw)
                {
                    k1 = 0;
                    k2 = 2 * i;
                    z = k2 + 1;
                }
                else if ((i + hw) > (n - 1))
                {
                    k1 = i - n + i + 1;
                    k2 = n - 1;
                    z = k2 - k1 + 1;
                }
                else
                {
                    k1 = i - hw;
                    k2 = i + hw;
                    z = _window;
                }

                for (int j = k1; j <= k2; j++)
                {
                    tmp += _input[j];
                }
                result[i] = tmp / z;
            }

            return result;
        }
    }
}
