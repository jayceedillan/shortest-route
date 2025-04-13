using SharedLogic.Models;
using SharedLogic.Services;
using System.Collections.Generic;
using Xunit;

namespace ShortestRouteFinder.Tests.Services
{
    public class ShortestPathCalculatorTests
    {
        private readonly ShortestPathCalculator _shortestPathCalculator;
        private readonly Dictionary<string, List<RouteLink>> _routeLinks;

        public ShortestPathCalculatorTests()
        {
            _shortestPathCalculator = new ShortestPathCalculator();
            _routeLinks = _shortestPathCalculator.InitializeRouteLinks();
        }

        [Fact]
        public void CalculateShortestPath_ValidPath_ReturnsCorrectPathAndDistance()
        {
            // Arrange
            var start = "A";
            var end = "D";

            // Act
            ShortestPathResult result = _shortestPathCalculator.CalculateShortestPath(start, end, _routeLinks);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(11, result.Distance);
            Assert.Equal(new List<string> { "A", "B", "F","G", "D" }, result.Path);
        }
       
        [Fact]
        public void CalculateShortestPath_SameStartAndEnd_ReturnsZeroDistance()
        {
            // Arrange
            var start = "A";

            // Act
            ShortestPathResult result = _shortestPathCalculator.CalculateShortestPath(start, start, _routeLinks);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Distance);
            Assert.Equal(new List<string> { "A" }, result.Path);
        }

        [Fact]
        public void CalculateShortestPath_NonExistingNode_ReturnsNegativeOne()
        {
            // Arrange
            var start = "X";
            var end = "Y";

            // Act
            ShortestPathResult result = _shortestPathCalculator.CalculateShortestPath(start, end, _routeLinks);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(-1, result.Distance);
            Assert.Empty(result.Path);
        }

        [Fact]
        public void CalculateShortestPath_UnreachableNode_ReturnsNegativeOne()
        {
            // Arrange
            var start = "A";
            var end = "Z"; 

            // Act
            ShortestPathResult result = _shortestPathCalculator.CalculateShortestPath(start, end, _routeLinks);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(-1, result.Distance);
            Assert.Empty(result.Path);
        }

        [Fact]
        public void CalculateShortestPath_ValidPath_CaseInsensitiveInput()
        {
            // Arrange
            var start = "a"; // Lowercase
            var end = "d";

            // Act
            ShortestPathResult result = _shortestPathCalculator.CalculateShortestPath(start, end, _routeLinks);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Distance > 0);
            Assert.True(result.Path.Count > 1);
        }

        [Fact]
        public void StartToEnd_ShouldReturnValidPath()
        {
            // Arrange
            var start = "A"; 
            var end = "I";

            // Act
            ShortestPathResult result = _shortestPathCalculator.CalculateShortestPath(start, end, _routeLinks);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(15, result.Distance);
            Assert.Equal(new List<string> { "A", "B", "F","G", "I" }, result.Path);
           
        }
    }
}
