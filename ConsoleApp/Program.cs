using SharedLogic.Models;
using SharedLogic.Services;

var shortestPathCalculator = new ShortestPathCalculator();

var routeLinks = shortestPathCalculator.InitializeRouteLinks();

var result = shortestPathCalculator.CalculateShortestPath("A", "I", routeLinks);

if (result.Distance != -1)
{
    Console.WriteLine("Shortest Path:");
    foreach (var node in result.Path)
    {
        Console.Write(node + " ");
    }
    Console.WriteLine($"\nTotal Distance: {result.Distance}");
}
else
{
    Console.WriteLine("No path found.");
}

Console.ReadLine();
