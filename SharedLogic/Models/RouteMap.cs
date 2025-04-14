using System.Collections.Generic;

namespace SharedLogic.Models
{
    public class RouteMap
    {
        public Dictionary<string, List<RouteLink>> AdjList { get; set; } = new Dictionary<string, List<RouteLink>>();

       
        public void AddRouteLink(string from, string to, int distance)
        {
            if (!AdjList.ContainsKey(from))
                AdjList[from] = new List<RouteLink>();

            AdjList[from].Add(new RouteLink(to, distance));

            if (!AdjList.ContainsKey(to))
                AdjList[to] = new List<RouteLink>();
        }


    }
}
