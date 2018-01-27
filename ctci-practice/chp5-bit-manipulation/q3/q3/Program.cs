using System;

namespace q3
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetLongestConsecutiveOnes(1775);
            Console.WriteLine(result);
        }

        static int GetLongestConsecutiveOnes(int number)
        {
            var lengthSoFar = 0;

            var maxLength = 0;
            var indexForMaxLength = 0;
            var binaryString = GetBinaryString(number);

            for (var i = binaryString.Length - 1; i >= 0 ; i--)
            {
                if (binaryString[i] == '0')
                {
                    indexForMaxLength = i;
                    maxLength = binaryString.Length - i - 1;
                    break;
                }
            }


            for (var i = indexForMaxLength - 1; i >= 0; i--)
            {
                if (binaryString[i] == '0')
                {
                    if (lengthSoFar >= maxLength)
                    {
                        maxLength = lengthSoFar;
                        indexForMaxLength = i;
                    }
                    lengthSoFar = 0;
                }
                else
                {
                    lengthSoFar++;
                }
            }

            var leftLength = 0;
            for (var i = indexForMaxLength - 1; i >= 0; i--)
            {
                if (binaryString[i] == '0')
                {
                    break;
                }
                leftLength++;
            }

            var rightLength = 0;
            for (var i = indexForMaxLength + 1; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '0')
                {
                    break;
                }
                rightLength++;
            }

            return leftLength + rightLength + 1;
        }

        static string GetBinaryString(int num)
        {
            return "11011101111";
        }
    }
}

