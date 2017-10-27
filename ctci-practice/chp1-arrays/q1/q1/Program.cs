using System;

namespace q1
{
    class Program
    {
        static bool IsUniqueNoDataStructure(string str)
        {
            var result = true;
            var mask = 0;
            for (var i = 0; i < str.Length; i++)
            {
                var ascii = i - 'a';
                
                var bitVal = 1 << ascii;
                var maskResult = bitVal & mask;
                if (maskResult > 0)
                {
                    result = false;
                    break;
                }
                mask = mask | bitVal;
            }
            return result;
        }

        static bool IsUnique(string str)
        {
            var result = true;
            var len = str.Length;
            var countArr = new int[26];

            for (var i = 0; i < len; i++)
            {
                if (countArr[str[i] - 'a'] == 0)
                {
                    countArr[str[i] - 'a']++;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            //var result = IsUnique(str);
            var result = IsUniqueNoDataStructure(str);
            Console.WriteLine(result);
        }
    }
}
