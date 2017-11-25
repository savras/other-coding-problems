using System;

namespace q7
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var chr = str.ToCharArray();
            var len = str.Length;
            PermuteUniqueString(chr, len, 0);
        }

        private static void Swap(char[] str, int i, int j)
        {
            var temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }

        private static void PermuteUniqueString(char[] str, int len, int baseIndex)
        {
            if (baseIndex == len)
            {
                Console.WriteLine(str);
            }
            else
            {
                for (var i = baseIndex; i < len; i++)
                {
                    Swap(str, baseIndex, i);
                    PermuteUniqueString(str, len, baseIndex + 1);
                    Swap(str, baseIndex, i);
                }
            }
        }
    }
}
