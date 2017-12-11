// Assumption - case insensitive => just use all lowercase
// Assumption - No digits (So no Natural vs Alphabetical sort)
// Assumption - all unique strings

using System;
using System.Collections.Generic;

namespace q5
{
    class Program
    {
        static bool SearchWordIsSmaller(string searchWord, string listWord)
        {
            if (listWord == string.Empty)
            {
                return false;
            }

            var swLength = searchWord.Length;
            var iwLength = listWord.Length;

            int shorterStringLength;
            bool result;

            // Default when the shortest string ties with the longest (up to the max length of shortest string)
            if (swLength > iwLength)
            {
                shorterStringLength = iwLength;
                result = false;
            }
            else
            {
                shorterStringLength = swLength;
                result = true;
            }

            for (var i = 0; i < shorterStringLength; i++)
            {
                if (searchWord[i] < listWord[i])
                {
                    result = true;
                    break;
                }
                else if (searchWord[i] > listWord[i])
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        static int Find(List<string> input, string word)
        {
            var low = 0;
            var high = input.Count - 1;

            var result = -1;
            while (low <= high)
            {
                var mid = low + (high - low)/2;

                if (input[mid] == word)
                {
                    result = mid;
                    break;
                }

                var counter = mid;
                while (input[counter] == "" && mid > low)
                {
                    counter--;
                }

                if (SearchWordIsSmaller(word, input[counter]))
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

            }
            return result;
        }

        static void Main(string[] args)
        {
            //var input = new List<string>
            //{
            //    "", "", ""
            //};

            //var input = new List<string>
            //{
            //    "", "", "custard"
            //};

            //var input = new List<string>
            //{
            //    "apple", "custard", "pie"
            //};

            var input = new List<string>
            {
                "", "apple", "", "", "",
                "custard", "", "",
                "jeep", "", "", "",
                "zap", "", ""
            };

            var word = Console.ReadLine();
            var index = Find(input, word);

            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("Word not found");
            }
        }
    }
}