using System;

namespace ConnectedCellInGrid
{
    class Program
    {
        private static int[][] _grid;
        private static int _n;
        private static int _m;

        static void Main(String[] args)
        {
            _n = Convert.ToInt32(Console.ReadLine());
            _m = Convert.ToInt32(Console.ReadLine());
            _grid = new int[_n][];
            
            for (int grid_i = 0; grid_i < _n; grid_i++)
            {
                string[] grid_temp = Console.ReadLine().Split(' ');
                _grid[grid_i] = Array.ConvertAll(grid_temp, Int32.Parse);
            }
            var max = 0;
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                     max = Math.Max(max, FindRegionLength(i, j));
                }
            }
            Console.WriteLine(max);
        }

        private static int FindRegionLength(int row, int column)
        {
            if (!IsInsideOfBoundaries(row, column))
                return 0;
         
            if (_grid[row][column] == 0)
                return 0;
            
            int regionStreak = 1;
            _grid[row][column] = 0;

            regionStreak += FindRegionLength(row + 1, column);
            regionStreak += FindRegionLength(row - 1, column);
            regionStreak += FindRegionLength(row, column + 1);
            regionStreak += FindRegionLength(row, column - 1);
            regionStreak += FindRegionLength(row - 1, column - 1);
            regionStreak += FindRegionLength(row - 1, column + 1);
            regionStreak += FindRegionLength(row + 1, column - 1);
            regionStreak += FindRegionLength(row + 1, column + 1);

            return regionStreak;
        }

        private static bool IsInsideOfBoundaries(int row, int column)
        {
            return row >= 0 && row < _n && column >= 0 && column < _m;
        }
    }
}