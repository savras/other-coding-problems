using System;
using System.Text;

namespace q6
{
    class Program
    {
        static void Main(string[] args)
        {
            //var str = "aaabbbCCCdddEEEEEEEEa";
            var str = "abc";
            var result = GetCompressedString(str);
            Console.WriteLine(result);
        }

        static string GetCompressedString(string str)
        {
            str = str + "-";    // Trigger change at the end of the string
            var lastIndex = 0;
            var lastChar = str[lastIndex];
            var strLen = str.Length;

            var sb = new StringBuilder();
            for (var i = 1; i < strLen; i++)
            {
                if (str[i] != lastChar)
                {
                    sb.Append(lastChar);
                    sb.Append(i - lastIndex);
                    lastIndex = i;
                    lastChar = str[i];
                }

                // Potentially check length of sb against strLen;
            }

            if (strLen - 1 < sb.Length)
            {
                return str.Substring(0, strLen - 1);
            }
            return sb.ToString();
        }
    }
}
