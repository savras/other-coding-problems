using System.Collections.Generic;

namespace q2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = new List<int[]>();
            var grid = new[,]
            {
                {1, 1, 1, 1},
                {1, 1, 0, 1},
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 1},
                {0, 0, 0, 1}
            };

            FindPath(grid, path, 0, 0);
        }

        static bool FindPath(int[,] grid, List<int[]> path, int r, int c)
        {
            var rowLen = grid.GetLength(0);
            var colLen = grid.GetLength(1);
            if (r >= rowLen|| c >= colLen)
            {
                return false;
            }

            if (grid[r, c] == 0)
            {
                return false;
            }

            if (r == rowLen - 1 && c == colLen - 1)
            {
                path.Add(new[] {r, c});
                return true;
            }

            var foundEnd = FindPath(grid, path, r, c + 1) || FindPath(grid, path, r + 1, c);

            if (foundEnd)
            {
                path.Add(new[] {r, c});
            }

            return foundEnd;
        }
    }
}