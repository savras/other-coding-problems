using System.Collections.Generic;

namespace Dijkstra
{
    public class Dijkstra
    {
        private readonly List<List<Node>> _adjList;
        private readonly List<List<int>> _distance;
        private HashSet<int> _visited;
        private List<int> _spt;
        private Heap<Node> _heap;

        public Dijkstra(List<List<Node>> adjList, List<List<int>> distance)
        {
            _adjList = adjList;
            _distance = distance;
            _visited = new HashSet<int>();
            _heap = new Heap<Node>();
            _spt = new List<int>(_adjList.Count) { int.MaxValue };
        }

        public void GetShortestPath(int source, int destination)
        {
            _spt[source] = 0;

            var currentNode = source;
            while (currentNode != destination)
            {
                for (var i = 0; i < _adjList[currentNode].Count; i++)
                {
                    var node = new Node
                    {
                        Id = _adjList[currentNode][i].Id,
                        Distance = _distance[currentNode][i] + _spt[currentNode]
                    };

                    // No need to update priority. 
                    // Just push a duplicate copy: http://www.geeksforgeeks.org/dijkstras-shortest-path-algorithm-using-priority_queue-stl/
                    _heap.Insert(node);
                }

                var shortestPathDistanceNode = _heap.ExtractMin();
                if (_spt[shortestPathDistanceNode.Id] > shortestPathDistanceNode.Distance)
                {
                    _spt[shortestPathDistanceNode.Id] = shortestPathDistanceNode.Distance;
                }
                currentNode = shortestPathDistanceNode.Id;
            }
        }
    }
}
