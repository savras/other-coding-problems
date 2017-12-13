using System;
using System.Collections.Generic;

namespace q1
{
    class Program
    {
        static List<List<int>> GetAdjacencyList()
        {

            return new List<List<int>> {
                new List<int>{1, 2},
                new List<int>{3},
                new List<int>{3, 4},
                new List<int>(),
                new List<int> {3}
            };
        }

        // Assume non-disjoint list
        static bool DFS(List<List<int>> adjList, int source, int destination)
        {
            var result = false;
            var visited = new HashSet<int> { source };

            var stack = new Stack<int>(adjList[source]);
            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (!visited.Contains(current))
                {
                    visited.Add(current);

                    foreach (var neightbour in adjList[current])
                    {
                        stack.Push(neightbour);
                    }

                    if (destination == current)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var adjList = GetAdjacencyList();

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());
            var hasPath = DFS(adjList, source, destination);

            Console.WriteLine(hasPath);
        }
    }
}
