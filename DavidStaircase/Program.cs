using System;
using System.Collections.Generic;

namespace DavidStaircase
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < s; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                _steps = n;
                int result = CalcStaircaseOptionsIteratively(_steps);
                //int result = CalcStaircaseOptionsMemo();
                Console.WriteLine(result);
            }
        }

        private static int CalcStaircaseOptionsIteratively(int steps)
        {
            if (steps < 1)
                return 0;
            var paths = new int[3];
            paths[0] = 1;
            paths[1] = 2;
            paths[2] = 4;
            if (steps < 3)
                return paths[steps - 1];
            for (var i = 3; i < steps; i++)
            {
                var count = paths[0] + paths[1] + paths[2];
                paths[0] = paths[1];
                paths[1] = paths[2];
                paths[2] = count;
            }

            return paths[2];
        }

        private static int CalcStaircaseOptionsMemo()
        {
            _memo = new int[_steps + 1];
            var result = CalcRecursive(_steps);
            return result;
        }

        private static int _steps;
        private static int[] _memo;

        private static int CalcRecursive(int steps)
        {
            if (steps < 0)
                return 0;
            if (steps == 0)
                return 1;

            if (_memo[steps] == 0)
            {
                _memo[steps] = CalcRecursive(steps - 1) + CalcRecursive(steps - 2) + CalcRecursive(steps - 3);
            }
            return _memo[steps];
        }
    }
}