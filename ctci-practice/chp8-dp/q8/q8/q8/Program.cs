using System;
using System.Collections.Generic;
using System.Linq;

namespace q8
{
    class Program
    {
        static void Swap(char[] str, int index1, int index2)
        {
            var temp = str[index1];
            str[index1] = str[index2];
            str[index2] = temp;
        }

        static void Permute(char[] str, int index, HashSet<string> hs)
        {
            if (index >= str.Length && !hs.Contains(new string(str)))
            {
                Console.WriteLine(new string(str));
                hs.Add(new string(str));
                return;
            }

            var hsLocal = new HashSet<char>();
            for (var i = index; i < str.Length; i++)
            {
                if (!hsLocal.Contains(str[i]))
                {
                    hsLocal.Add(str[i]);
                    Swap(str, i, index);
                    Permute(str, index + 1, hs);
                    Swap(str, index, i);
                }
            }
        }

        static void Main(string[] args)
        {
            var hs = new HashSet<string>();
            var str = "AAABBC";
            Permute(str.ToCharArray(), 0, hs);
        }
    }
}
