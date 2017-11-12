using System;
using System.Collections.Generic;

namespace q7
{
    class Program
    {

        static List<int> PerformTopoSort(List<List<int>> adjList)
        {
            var visited = new HashSet<int>();
            var result = new List<int>();
            visited.Add(0);
            PerformDfs(visited, result, adjList, 0);

            return result;
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

            result.Add(nodeIndex);
        }

        // Topological sort
        // Assume graph is DAG
        static void Main(string[] args)
        {
            var adjList = new List<List<int>>
            {
                new List<int> { 1, 4, 6 },
                new List<int> { 2 },
                new List<int> { 3, 5},
                new List<int> (),
                new List<int> (),
                new List<int> { 3 },
                new List<int> { 5, 7, 9 },
                new List<int> { 8 },
                new List<int> (),
                new List<int> ()
            };

            var result = PerformTopoSort(adjList);

            // Print result
            var size = result.Count;
            for (var i = 0; i < size; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
