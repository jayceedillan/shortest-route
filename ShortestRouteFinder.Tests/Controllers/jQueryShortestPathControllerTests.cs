using SharedLogic.Models;
using SharedLogic.Services;
using System.Collections.Generic;
using Xunit;

namespace ShortestRouteFinder.Tests.Controllers
{ 
    public class jQueryShortestPathControllerTests
    {
        private readonly ShortestPathCalculator _shortestPathCalculator;
        private readonly Dictionary<string, List<RouteLink>> _routeLinks;

        public jQueryShortestPathControllerTests()
        { 
            _shortestPathCalculator = new ShortestPathCalculator();
            _routeLinks = _shortestPathCalculator.InitializeRouteLinks();
        }

        [Fact]
        public void CalculateShortestPath_ValidNodes_ReturnsExpectedPathAndDistance()
        {
            var result = _shortestPathCalculator.CalculateShortestPath("B", "H", _routeLinks);

            Assert.NotNull(result);
            Assert.Equal(8, result.Distance);
            Assert.Equal(new List<string> { "B", "F", "H" }, result.Path);
        }

        [Fact]
        public void CalculateShortestPath_ValidStartAndEnd_ReturnsCorrectDistanceAndPath()
        {
            var result = _shortestPathCalculator.CalculateShortestPath("A", "I", _routeLinks);

            Assert.NotNull(result);
            Assert.Equal(15, result.Distance);
            Assert.Equal(new List<string> { "A", "B", "F","G", "I" }, result.Path);
        }
    
        [Fact]
        public void CalculateShortestPath_InvalidNodes_ReturnsEmptyPathAndNegativeDistance()
        {
            var result = _shortestPathCalculator.CalculateShortestPath("X", "Y", _routeLinks);

            Assert.NotNull(result);
            Assert.Equal(-1, result.Distance);
            Assert.Empty(result.Path);
        }

        [Fact]
        public void CalculateShortestPath_SameStartAndEnd_ReturnsZeroDistance()
        {
            var result = _shortestPathCalculator.CalculateShortestPath("A", "A", _routeLinks);

            Assert.NotNull(result);
            Assert.Equal(0, result.Distance);
            Assert.Equal(new List<string> { "A" }, result.Path);
        }
    }
}
