using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1101101, 1001
            var result = InsertBits(109, 9, 2, 5);

        }

        public static int InsertBits(int n, int m, int i, int j)
        {
            var mask = ~0;

            var noOfBitsInM = j - i + 1;
            mask = mask << noOfBitsInM;     // ....111110000 for no of bits in M == 4;

            // Fill lsb with 1's
            for (var p = noOfBitsInM; p <= j; p++)
            {
                mask = mask << 1;
                mask |= 1;
            }

            var clearedBits = mask & n;

            var msbIndexOfM = j - i;
            var moveMLeft = m << j - msbIndexOfM;
            var result = clearedBits | moveMLeft;


            return result;
        }
    }
}
