using SharedLogic.Models;
using System;
using System.Collections.Generic;

namespace SharedLogic.Services
{
    public class ShortestPathCalculator
    {
        public Dictionary<string, List<RouteLink>> InitializeRouteLinks()
        {
            var routeMap = new RouteMap();
            routeMap.AddRouteLink("E", "B", 2);
            routeMap.AddRouteLink("A", "B", 4);
            routeMap.AddRouteLink("B", "A", 4);
            routeMap.AddRouteLink("A", "C", 6);
            routeMap.AddRouteLink("C", "A", 6);
            routeMap.AddRouteLink("C", "D", 8);
            routeMap.AddRouteLink("D", "C", 8);
            routeMap.AddRouteLink("E", "D", 4);
            routeMap.AddRouteLink("D", "E", 4);
            routeMap.AddRouteLink("B", "F", 2);
            routeMap.AddRouteLink("F", "B", 2);
            routeMap.AddRouteLink("F", "E", 3);
            routeMap.AddRouteLink("E", "F", 3);
            routeMap.AddRouteLink("F", "H", 6);
            routeMap.AddRouteLink("H", "F", 6);
            routeMap.AddRouteLink("F", "G", 4);
            routeMap.AddRouteLink("G", "F", 4);
            routeMap.AddRouteLink("E", "I", 8);
            routeMap.AddRouteLink("I", "E", 8);
            routeMap.AddRouteLink("D", "G", 1);
            routeMap.AddRouteLink("G", "D", 1);
            routeMap.AddRouteLink("H", "G", 5);
            routeMap.AddRouteLink("G", "H", 5);
            routeMap.AddRouteLink("G", "I", 5);
            routeMap.AddRouteLink("I", "G", 5);
           
            return routeMap.AdjList;
        }

        public ShortestPathResult CalculateShortestPath(string start, string end, Dictionary<string, List<RouteLink>> routeMaps)
        {
            start = start.ToUpper();
            end = end.ToUpper();

            if (routeMaps == null || !routeMaps.ContainsKey(start) || !routeMaps.ContainsKey(end))
            {
                return new ShortestPathResult
                {
                    Path = new List<string>(),
                    Distance = -1
                };
            }

            var nodeDistanceMap = new Dictionary<string, int>();
            var pathHistory = new Dictionary<string, string>();
            var priorityQueue = new CustomPriorityQueue();

            // Initialize all nodes with maximum distance and no previous node
            foreach (var node in routeMaps.Keys)
            {
                nodeDistanceMap[node] = int.MaxValue;
                pathHistory[node] = null;
            }

            nodeDistanceMap[start] = 0;
            priorityQueue.Enqueue(start, 0);

            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.Dequeue();

                if (currentNode == end)
                    break;

                if (!routeMaps.ContainsKey(currentNode))
                    continue;

                foreach (var routeMap in routeMaps[currentNode])
                {
                    int newDistance = nodeDistanceMap[currentNode] + routeMap.Distance;
                    int distanceTo = nodeDistanceMap[routeMap.To];
                    if (newDistance < distanceTo)
                    {
                        nodeDistanceMap[routeMap.To] = newDistance;
                        pathHistory[routeMap.To] = currentNode;
                        priorityQueue.Enqueue(routeMap.To, newDistance);
                    }
                }
            }


            return nodeDistanceMap[end] == int.MaxValue
                ? new ShortestPathResult { Path = new List<string>(), Distance = -1 }
                : new ShortestPathResult
                {
                    Path = ReconstructPath(pathHistory, end),
                    Distance = nodeDistanceMap[end]
                };
        }

        private List<string> ReconstructPath(Dictionary<string, string> pathHistory, string end)
        {
            var path = new List<string>();
            string current = end;

            // Traverse the `previous` dictionary backwards from the end to the start node
            while (current != null)
            {
                path.Insert(0, current);
                current = pathHistory[current];
            }

            return path;
        }
    }

    public class CustomPriorityQueue
    {
        private List<(string Element, int Priority)> _elements = new List<(string, int)>();

        public int Count => _elements.Count;

        public void Enqueue(string element, int priority)
        {
            _elements.Add((element, priority));
            _elements.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public string Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            var element = _elements[0].Element;
            _elements.RemoveAt(0);
            return element;
        }
    }
}
