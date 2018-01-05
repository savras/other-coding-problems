// Assumption : case insensitive. Alphabets only.

using System;

namespace q2
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "mahewiwivhee";
            var str2 = "eevihwiwehma";
            var result = IsPermutation(str1, str2);
            Console.WriteLine(result);
        }

        static bool IsPermutation(string str1, string str2)
        {
            str1 = str1.ToLower();
            str2 = str2.ToLower();

            if (str1.Length != str2.Length)
            {
                return false;
            }

            var arr = new int[26];
            for (var i = 0; i < str1.Length; i++)
            {
                var index = str1[i] - 'a';
                arr[index]++;
            }

            for (var i = 0; i < str2.Length; i++)
            {
                var index = str2[i] - 'a';
                arr[index]--;
            }

            var result = true;
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    result = false;
                    break;

                }
            }

            return result;
        }
    }
}
