using System;
using System.Text;

namespace q3
{
    class Program
    {
        static string URLify(string str)
        {
            var sb = new StringBuilder(str);
            var i = 0;
            while(i < sb.Length)
            {
                if (sb[i] != ' ') { i++; continue; }

                int j;
                for (j = i + 1; j < sb.Length; j++)
                {
                    if (sb[j] != ' ') { break; }
                }

                var substring = sb.ToString().Substring(j);
                sb.Insert(i, "%20");
                i += 3;
                sb.Remove(i, sb.Length - i);
                sb.Insert(i, substring);

                i++;
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            Console.WriteLine(URLify(str));
        }
    }
}
