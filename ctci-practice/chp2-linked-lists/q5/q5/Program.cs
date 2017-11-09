using System.Xml;

namespace q5
{
    class Program
    {
        Node Sum(Node head1, Node head2)
        {
            var num1 = GetInt(head1);
            var num2 = GetInt(head2);
            var sum = num1 + num2;

            var resultHead = BuildLinkedList(sum);
            return resultHead;
        }

        Node SumReversed(Node head1, Node head2)
        {
            var num1 = GetIntReversed(head1);
            var num2 = GetIntReversed(head2);
            var sum = num1 + num2;

            var resultHead = BuildLinkedList(sum);
            return resultHead;
        }

        int GetIntReversed(Node head)
        {
            var stack = new Stack<int>();

            var current = head;
            while (current != null)
            {
                stack.Push(current.Value());
                current = current.Next();
            }

            var result = 0;
            var multiplier = 1;
            while (!stack.Empty())
            {
                result += multiplier*stack.Top();
                stack.Pop();
                multiplier *= 10;
            }

            return result;
        }

        Node BuildLinkedList(int num)
        {
            var head = new Node();
            while (num > 0)
            {
                var value = num%10;
                head.AddNewNode(value);
                value = value/10;
            }
            return head;
        }

        int GetInt(Node head)
        {
            var current = head;
            var multiplier = 1;
            var runningSum = 0;
            while (current != null)
            {
                runningSum += (current.Value()*multiplier);
                current = current.Next();
                multiplier *= 10;
            }
            return runningSum;
        }

        static void Main(string[] args)
        {
            // Call Sum() & SumReversed();
        }
    }
}
