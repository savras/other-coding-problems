using System;
using System.Text;

namespace q2
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetBinary(10.75);
            Console.WriteLine(result);
        }

        public static string GetBinary(double num)
        {
            if (num < 0 || num > 1)
            {
                return "Number is not in the valid range of 0 and 1";
            }

            var deci = (int)num;
            var fraction = num - deci;

            var result = new StringBuilder();

            result.Append(GetDecimalBinary(deci));
            result.Append(".");
            result.Append(GetFractionBinary(fraction));

            return result.ToString();
        }

        public static string GetDecimalBinary(int deci)
        {
            if (deci == 0)
            {
                return "0";
            }

            var result = new StringBuilder();
            while (deci > 0)
            {
                var remainder = deci % 2;
                deci = deci / 2;
                result.Insert(0, remainder);
            }
            return result.ToString();
        }

        public static string GetFractionBinary(double fraction)
        {
            var result = new StringBuilder();
            while (fraction > 0)
            {
                double multiplicationResult = fraction * 2;
                double deci = (int)multiplicationResult;
                fraction = multiplicationResult - deci;
                result.Append(deci);
            }
            return result.ToString();
        }
    }
}
