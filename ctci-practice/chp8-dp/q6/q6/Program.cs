using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace q6
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 20;

            var t1 = new Stack<int>();
            var t2 = new Stack<int>();
            var t3 = new Stack<int>();
            for (var i = 1; i <= n; i++)
            {
                t1.Push(i);
            }

            Solve(n, t1, t2, t3);
        }

        private static void Solve(int n, Stack<int> main, Stack<int> buffer, Stack<int> end)
        {
            if (n == 0)
            {
                return;
            }
            Solve(n - 1, main, end, buffer);

            if (main.Count > 0)
            {
                var val = main.Peek();
                main.Pop();
                end.Push(val);
            }

            Solve(n - 1, buffer, main , end);
        }
    }
} 