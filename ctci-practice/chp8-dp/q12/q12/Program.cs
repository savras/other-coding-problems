using System;

namespace q12
{
    class Program
    {

        static bool IsValidPlacement(int[] cols, int row, int col)
        {
            // Check validy of column
            if (cols[col] != 0) { return false; }

            // Given current column, col, we can find out if there's a queen in the column
            // by checking cols[i] != 0
            // If rowDist == colDist, then we know there is a queen diagonally.
            // Value in cols[i] is the row of the other queens (if not 0)
            // Index i is the column of the other queens
            var result = true;
            for (var i = 0; i < cols.Length; i++)
            {
                if (cols[i] != 0 && 
                    Math.Abs(col - i) == (cols[i] - row))
                {
                    result = false;
                }
            }
            return result;
        }

        static int GetNumberOfWays(int[] cols, int row)
        {
            // 1.Note that we recurse upwards towards the upper rows. 
            // This means that the rows will always be unique
            // 2. Note that we can have one array to check whether a column has a queen or not.
            if (row == 0) { return 1; }  // We have made it all the way and havent found an invalid placement.

            var result = 0;
            for (var j = 0; j < cols.Length; j++)
            {
                if (IsValidPlacement(cols, row, j))
                {
                    cols[j] = row;
                    result += GetNumberOfWays(cols, row - 1);
                    cols[j] = 0;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            // We store the value of the 1-based row index in cols array.
            // We use the index of cols array as the column index
            const int n = 8;
            var cols = new int[n];

            var result = GetNumberOfWays(cols, n);
            Console.WriteLine(result);
        }
    }
}
