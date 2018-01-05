using System;
using System.Collections.Generic;
using System.Linq;

namespace q4
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "tactcoa";
            var result = IsStringPermutationOfPalindrome(str);
            Console.WriteLine(result);
        }

        static bool IsStringPermutationOfPalindrome(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            var len = str.Length;
            var dict = new Dictionary<char, int>(); // Can also use bool e.g true to represent odd occurrences and false for even occurrences.
            for (var i = 0; i < len; i++)
            {
                if (dict.ContainsKey(str[i]))
                {
                    dict[str[i]]++;
                }
                else
                {
                    dict.Add(str[i], 1);
                }
            }

            var result = true;
            var oddResultCount = 0;
            if (len%2 == 0)
            {
                if (dict.Any(pair => pair.Value%2 != 0))
                {
                    result = false;
                }
            }
            else
            {
                foreach (var pair in dict.Where(pair => pair.Value%2 != 0))
                {
                    oddResultCount++;
                    if (oddResultCount > 1)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
