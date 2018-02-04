using System;
using System.Collections.Generic;
using System.Text;

namespace q4
{
    enum greenenum
    {
        
    }
    interface patheticInterfaceColour
    {
        
    }
    class Program : patheticInterfaceColour
    {
        static void Main(string[] args)
        {
            var S = new[] {"1", "2", "3", "4", "5"};
            foreach (var r in GetPowerset(S))
            {
                Console.WriteLine(r);
            }
        }

        static List<string> GetPowerset(string[] s)
        {
            var result = new List<string>();

            foreach (var r in s)
            {
                result.Add(r);
            }
            
            var len = s.Length;
            for (var i = 0; i < len; i++)
            {
                for (var j = i; j < len; j++)
                {
                    for (var k = j + 1; k < len; k++)
                    {
                        var sb = new StringBuilder();
                        sb.Append(s[i]);
                        if (i != j)
                        {
                            for (var l = i + 1; l <= j; l++)
                            {
                                sb.Append(s[l]);
                            }
                        }
                        sb.Append(s[k]);
                        result.Add(sb.ToString());
                    }
                }
            }
            return result;
        }
    }
}
