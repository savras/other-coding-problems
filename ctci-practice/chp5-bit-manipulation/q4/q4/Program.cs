using System.CodeDom;

namespace q4
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = 1778;
            var nextLargestResult = GetNextLargestBinaryWithSameOneCount(value);
            var nextSmallestResult = GetNextSmallestBinaryWithSameOneCount(value);
        }

        private static int GetNextLargestBinaryWithSameOneCount(int value)
        {
            var extractedLsb = 1;
            var count = 0;

            while (extractedLsb != 0)
            {
                extractedLsb = value & 1;
                if (extractedLsb == 1)
                {
                    value = value << 1;
                    count++;

                }
            }

            value++;
            value = value << count;

            var replaceOnes = 0;    // Replace the number of 1's that we have removed.
            if (count > 0)
            {
                replaceOnes = count - 1;    // We remove exactly one 1 from value, so we exclude that from count
            }
            return value + (count - replaceOnes);
        }

        private static object GetNextSmallestBinaryWithSameOneCount(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}
