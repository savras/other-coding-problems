using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace q1
{
    class Program
    {
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
            var result = IsUnique(str);
            Console.WriteLine(result);
        }
    }
}
