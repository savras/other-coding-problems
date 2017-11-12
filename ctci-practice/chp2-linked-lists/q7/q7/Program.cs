using System.Collections.Generic;

namespace q7
{
    class Program
    {

        static void PerformTopoSort(List<List<int>> adjList)
        {
            var visited = new HashSet<int>();
            var result = new List<int>();
            visited.Add(0);
            PerformDfs(visited, result, adjList, 0);
        }

        static void PerformDfs(HashSet<int> visited, List<int> result, List<List<int>> adjList, int nodeIndex)
        {
            foreach (var neighbour in adjList[nodeIndex])
            {
                if (!visited.Contains(neighbour))
                {
                    visited.Add(neighbour);
                    PerformDfs(visited, result, adjList, neighbour);
                }
            }
        }

        // Topological sort
        static void Main(string[] args)
        {
            var adjList = new List<List<int>>
            {
                new List<int> { 1, 2, 4 },
                new List<int> {3, 4, 6 }
            };

            PerformTopoSort(adjList);
        }
    }
}
