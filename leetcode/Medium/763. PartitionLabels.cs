using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Solution
    {

        public static IList<int> PartitionLabels(string S)
        {
            var startPosDict = new Dictionary<char, int>();
            var endPosDict = new Dictionary<char, int>();

            for (var i = 0; i < S.Length; i++)
            {
                if (!startPosDict.ContainsKey(S[i]))
                {
                    startPosDict.Add(S[i], i);
                    endPosDict.Add(S[i], i);
                }
                else
                {
                    endPosDict[S[i]] = i;
                }
            }

            var result = new List<int>();

            // Add dummy value at the end to trigger calculation
            endPosDict.Add('#', 999);
            startPosDict.Add('#', 999);

            var orderedStartPosDict = startPosDict.OrderBy(dict => dict.Value);
            var largestEndIndexSoFar = endPosDict[S[0]];
            var startIndexSoFar = startPosDict[S[0]];

            var counter = 0;
            foreach (var item in orderedStartPosDict)
            {
                counter++;
                if (counter == 1)
                {
                    // We have already recorded the information we need in the initialization of 
                    // largestEndIndexSoFar and startIndexSoFar above.
                    continue;
                }

                var key = item.Key;
                var startIndex = item.Value;
                var endIndex = endPosDict[key];

                if (startIndex < largestEndIndexSoFar && endIndex > largestEndIndexSoFar)
                {
                    largestEndIndexSoFar = endIndex;
                }
                else if (startIndex >= largestEndIndexSoFar)
                {
                    result.Add(largestEndIndexSoFar - startIndexSoFar + 1); // Inclusive
                    startIndexSoFar = item.Value;
                    largestEndIndexSoFar = endPosDict[item.Key];
                }
            }


            return result;
        }

        static void Main(string[] args)
        {

            //var result = PartitionLabels("ababcbacadefegdehijhklij");
            //var result = PartitionLabels("jajnnxkkemesdwgiyiqq);
            //var result = PartitionLabels("caedbdedda");
            var result = PartitionLabels("eaaaabaaec");
        }
    }
}
