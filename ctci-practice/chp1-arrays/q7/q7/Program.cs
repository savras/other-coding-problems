using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q7
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n, n];

            // if n %2 != 0, outer loop loops from i = 0 to i = n/2 (incl)
            // if n %2 == 0, outer loop loops from i = 0 to < n/2 -1
            var limit = n % 2 == 0 ? (n / 2) - 1 : (n / 2);

            for (var i = 0; i < limit; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var temp = arr[i,j];
                    arr[i,j] = arr[n - j,i];
                    arr[n - j,i] = arr[n,n - j];
                    arr[n,n - j] = arr[j,n];
                    arr[j,n] = temp;
                }
            }
        }
    }
}
