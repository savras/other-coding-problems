using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Solution
    {
        public static int[] AsteroidCollision(int[] asteroids)
        {
            var result = new List<int>();

            // ToDo:: Rename this to forwardMovingAsteroids.
            var fma = new Stack<int>();

            for (var i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] > 0)
                {
                    fma.Push(asteroids[i]);
                }
                else
                {
                    if (fma.Count == 0)
                    {
                        result.Add(asteroids[i]);
                        continue;
                    }

                    // Incoming asteroid blows up.
                    if (fma.Count > 0 && fma.Peek() > Math.Abs(asteroids[i]))
                    {
                        continue;
                    }

                    // Blow up all smaller asteroids going against incoming asteroid
                    while (fma.Count > 0 && fma.Peek() < Math.Abs(asteroids[i]))
                    {
                        fma.Pop();
                    }

                    // All smaller asteroids blew up, now check if the remaining one is of equal size.
                    if (fma.Count() > 0 && fma.Peek() == Math.Abs(asteroids[i]))
                    {
                        fma.Pop();
                        continue;
                    }

                    // Remaining one is larger
                    if (fma.Count() > 0 && fma.Peek() > Math.Abs(asteroids[i]))
                    {
                        continue;
                    }

                    // All asteroids are smaller than incoming one.
                    result.Add(asteroids[i]);
                }
            }

            var reverseFma = new Stack<int>();
            while (fma.Count > 0)
            {
                reverseFma.Push(fma.Peek());
                fma.Pop();
            }
            while (reverseFma.Count > 0)
            {
                result.Add(reverseFma.Peek());
                reverseFma.Pop();
            }

            return result.ToArray();
        }
        static void Main(string[] args)
        {
            AsteroidCollision(new[] {-2, -2, 1, -2});
        }
    }
}
