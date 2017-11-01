using System;

namespace q5
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var len1 = str1.Length;
            var len2 = str2.Length;

            bool result;
            if (Math.Abs(len1 - len2) > 1)
            {
                result = false;
            }
            else
            {
                if (len1 == len2)
                {
                    var diffCount = 0;
                    for (var i = 0; i < len1; i++)
                    {
                        if (str1[i] != str2[i])
                        {
                            diffCount++;
                        }

                        if (diffCount > 1)
                        {
                            break;
                        }
                    }
                    result = diffCount <= 1;
                }
                else
                {
                    string shorterString;
                    string longerString;

                    if (len1 < len2)
                    {
                        shorterString = str1;
                        longerString = str2;
                    }
                    else
                    {
                        shorterString = str2;
                        longerString = str1;
                    }

                    var diffCount = 0;
                    var sIndex = 0;
                    var lIndex = 0;

                    while(sIndex < shorterString.Length && lIndex < longerString.Length)
                    {
                        if (shorterString[sIndex] != longerString[lIndex])
                        {
                            diffCount++;
                            lIndex++;
                            continue;
                        }

                        sIndex++;
                        lIndex++;
                    }

                    result = diffCount <= 1 ;    // Add 1 to cater for length difference
                }
            }
            Console.WriteLine(result);

        }
    }
}
