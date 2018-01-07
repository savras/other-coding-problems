using System;

namespace q8
{
    class Program
    {
        static void Main(string[] args)
        {

            var matrix = new[,]
            {
                {1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 0, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 0, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            };

            var size = 10;
            ZeroOutMatrix(matrix, size);

            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void ZeroOutMatrix(int[,] matrix, int size)
        {
            var zeroOutFirstRow = false;
            var zeroOutFirstCol = false;

            for (var i = 0; i < size; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    zeroOutFirstCol = true;
                }

                if (matrix[0, i] == 0)
                {
                    zeroOutFirstRow = true;
                }

                if (zeroOutFirstRow && zeroOutFirstCol)
                {
                    break;
                }
            }

            for (var row = 1; row < size; row++)
            {
                for (var col= 1; col< size; col++)
                {
                    if (matrix[row,col] == 0)
                    {
                        matrix[0,col] = 0;
                        matrix[row,0] = 0;
                    }
                }
            }


            for (var i = 0; i < size; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    for (var j = 0; j < size; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }

                if (matrix[0, i] == 0)
                {
                    for (var j = 0; j < size; j++)
                    {
                        matrix[j, i] = 0;
                    }
                }
            }

            if (zeroOutFirstCol)
            {
                for (var i = 0; i < size; i++)
                {
                    matrix[i, 0] = 0;
                }
            }

            if (zeroOutFirstRow)
            {
                for (var i = 0; i < size; i++)
                {
                    matrix[0, i] = 0;
                }
            }
        }
    }
}
