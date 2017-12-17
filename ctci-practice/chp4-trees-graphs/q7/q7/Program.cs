using System;
using System.Collections.Generic;

namespace q7
{
    class Program
    {
        static List<List<int>> GetGraph()
        {
            return new List<List<int>>
            {
                new List<int>{ 3, 5 },
                new List<int>{ 5, 3 },
                new List<int>{ 4 },
                new List<int>{ 2 },
                new List<int>(),
                new List<int>()
            };
        }

        static void DFS(List<List<int>> graph, int current, HashSet<int> visited)
        {
            foreach (var neighbour in graph[current])
            {
                if (!visited.Contains(neighbour))
                {
                    visited.Add(neighbour);
                    DFS(graph, neighbour, visited);
                }
            }
            Console.Write($"{current} ");
        }

        static void Toposort(List<List<int>> graph)
        {
            var visited = new HashSet<int>();

            for(var i = 0; i < graph.Count; i++)
            {
                if (!visited.Contains(i))
                {
                    visited.Add(i);
                    DFS(graph, i, visited);
                }
            }
        }

        static void Main(string[] args)
        {
            var graph = GetGraph();
            Toposort(graph);
        }
    }
}
