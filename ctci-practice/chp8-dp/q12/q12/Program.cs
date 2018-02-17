using System;

namespace q12
{
    class Program
    {

        static bool IsValidPlacement(int[,] board, int row, int col)
        {

            return IsCheckDiagonal(board, row, col) &&
                   IsValidVertical(board, col) &&
                   IsValidHorizontal(board, row);
        }

        private static bool IsValidHorizontal(int[,] board, int row)
        {
            var oneCount = 0;
            for (var i = 0; i < board.GetLength(0); i++)
            { 
                oneCount += board[row, i];
            }
            return oneCount == 1;
        }

        private static bool IsValidVertical(int[,] board, int col)
        {
            var oneCount = 0;
            for (var i = 0; i < board.GetLength(0); i++)
            {
                oneCount += board[i, col];
            }
            return oneCount == 1;
        }

        private static bool IsCheckDiagonal(int[,] board, int row, int col)
        {
            var oneCount = 0;
            var len = board.GetLength(0) - 1;

            var r = row;
            var c = col;
            r--;
            c--;
            while (r >= 0 && c >= 0)
            {
                oneCount += board[r--, c--];
            }

            r = row;
            c = col;
            r++;
            c++;
            while (r < len && c < len)
            {
                oneCount += board[r++, c++];
            }

            r = row;
            c = col;
            r++;
            c--;
            while (r < len && c >= 0)
            {
                oneCount += board[r++, c--];
            }

            r = row;
            c = col;
            r--;
            c++;
            while (r >= 0 && c < len)
            {
                oneCount += board[r--, c++];
            }

            return oneCount == 0;
        }

        static int GetNumberOfWays(int[,] board, int row, int previousCol)
        {
            if (row < 0) { return 1; }

            var result = 0;
            for (var col = board.GetLength(1) - 1; col >= 0; col--)
            {
                board[row, col] = 1;

                if (IsValidPlacement(board, row, previousCol))
                {
                    result += GetNumberOfWays(board, row - 1, col);
                }

                board[row, col] = 0;
            }
            return result;
        }

        static void Main(string[] args)
        {
            var board = new[,]
            {
                //{0, 0, 0, 0},
                //{0, 0, 0, 0},
                //{0, 0, 0, 0},
                //{0, 0, 0, 0}
                
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
            };

            var startX = board.GetLength(0) - 1;
            var startY = board.GetLength(1) - 1;

            var result = GetNumberOfWays(board, startX, startY);
            Console.WriteLine(result);
        }
    }
}
