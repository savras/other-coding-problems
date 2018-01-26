using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q2
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetBinary(10.75);
            Console.WriteLine(result);
        }

        public static double GetBinary(double num)
        {
            int deci = (int)num;
            var fraction = num - deci;

            double result = 0.00; ;
            result += GetFractionBinary(fraction);
             result += GetDecimalBinary(deci);

            return result;
        }

        public static double GetDecimalBinary(int deci)
        {
            var result = 0;
            var multiplier = 1;
            while (deci > 0)
            {
                result += (deci % 2) * multiplier;
                deci = deci / 2;
                multiplier *= 10;
            }
            return result;
        }

        public static double GetFractionBinary(double fraction)
        {
            var result = 0.00;
            int multiplier = 10;
            while (fraction > 0)
            {
                double multiplicationResult = fraction * 2;
                double deci = (int)multiplicationResult;
                fraction = multiplicationResult - deci;
                result += deci / multiplier;
                multiplier *= 10;
            }
            return result;
        }
    }
}
