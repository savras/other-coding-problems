/*
 * Track last known number, and its state whether it is larger or smaller than its previous value.
 * Discover the next new number. If its larger than the current number, and its state is smaller than
 * its previous number, then just push to the array.
 * Otherwise, swap the newly discovered digit with the current digit, and push the current digit into the array.
 * Assumption, no contiguous values with the same digit
 * 
 * Better solution that allows us to only check odd / even indices is available
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace q11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<int> {5, 3, 6, 7, 8, 3, 2, 4, 2, 8, 2, 5, 4};

            var result = new int[input.Count];
            result[0] = input[0];
            var rightMostDigit = input[0];

            // true us larger than previous digit, false is smaller.
            var newlyDiscoveredDigit = input[1];
            var isCurrentGreaterThanPrevious = newlyDiscoveredDigit < rightMostDigit;

            for (var i = 1; i < input.Count; i++)
            {
                newlyDiscoveredDigit = input[i];
                if ((newlyDiscoveredDigit > rightMostDigit && isCurrentGreaterThanPrevious) ||
                    (newlyDiscoveredDigit < rightMostDigit && !isCurrentGreaterThanPrevious))
                {
                    var temp = result[i - 1];
                    result[i - 1] = input[i];
                    result[i] = temp;
                    isCurrentGreaterThanPrevious = !isCurrentGreaterThanPrevious;
                    continue;
                }
                else
                {
                    result[i] = input[i];
                    
                }
                isCurrentGreaterThanPrevious = !isCurrentGreaterThanPrevious;
                rightMostDigit = result[i];
            }

            foreach (var t in result)
            {
                Console.Write($"{t} ");
            }
        }
    }
}
