using System;
using System.Collections.Generic;

namespace q6
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;

            var t1 = new Stack<int>();
            for (var i = 1; i <= 4; i++)
            {
                t1.Push(i);
            }

            var stacks = new[]
            {
                t1, new Stack<int>(), new Stack<int>()
            };

            Solve(stacks, true, 0, n);
        }

        private static void Solve(Stack<int>[] stacks, bool isOddTurn, int onePositionIndex, int n)
        {
            while (stacks[2].Count < n)
            {
                // if isOddTurn, move 1 to the right
                if (isOddTurn)
                {
                    stacks[onePositionIndex].Pop();
                    onePositionIndex++;
                    if (onePositionIndex > 2)
                    {
                        onePositionIndex = 0;
                    }
                    stacks[onePositionIndex].Push(1);
                }
                // else move smallest non-1 to the only valid position
                else
                {
                    MoveSmallestNonOne(stacks, onePositionIndex);
                }

                isOddTurn = !isOddTurn;
            }
        }

        private static void MoveSmallestNonOne(Stack<int>[] stacks, int onePositionIndex)
        {
            var index1 = 0;
            var index2 = 0;
            switch (onePositionIndex)
            {
                case 0:
                {
                    index1 = 1;
                    index2 = 2;
                    break;
                }
                case 1:
                {
                    index1 = 0;
                    index2 = 2;
                    break;
                }
                case 2:
                {
                    index1 = 0;
                    index2 = 1;
                    break;
                }
            }

            int smallerValue;
            int smallerStackIndex;
            int largerStackIndex;
            if (stacks[index1].Count == 0)
            {
                smallerValue = stacks[index2].Peek();
                smallerStackIndex = index1;
                largerStackIndex = index2;
            }
            else if (stacks[index2].Count == 0)
            {
                smallerValue = stacks[index1].Peek();
                smallerStackIndex = index2;
                largerStackIndex = index1;
            }
            else if (stacks[index1].Peek() < stacks[index2].Peek())
            {
                smallerValue = stacks[index1].Peek();
                smallerStackIndex = index1;
                largerStackIndex = index2;
            }
            else
            {
                smallerValue = stacks[index2].Peek();
                smallerStackIndex = index2;
                largerStackIndex = index1;
            }


            if (stacks[largerStackIndex].Count != 0)
            {
                stacks[largerStackIndex].Pop();
            }
            stacks[smallerStackIndex].Push(smallerValue);
        }
    }
}