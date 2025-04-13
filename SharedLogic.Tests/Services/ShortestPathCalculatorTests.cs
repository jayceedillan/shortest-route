namespace SharedLogic.Tests.Services
{
    using global::SharedLogic.Models;
    using global::SharedLogic.Services;
    using System.Collections.Generic;
    using Xunit;

    namespace SharedLogic.Tests
    {
        public class ShortestPathCalculatorTests
        {
            private readonly ShortestPathCalculator _calculator;

            public ShortestPathCalculatorTests()
            {
                _calculator = new ShortestPathCalculator();
            }

            [Fact]
            public void CalculateShortestPath_ValidPath_ReturnsCorrectPathAndDistance()
            {
                // Arrange
                var start = "B";
                var end = "D";

                // Act
                ShortestPathResult result = _calculator.CalculateShortestPath(start, end);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(6, result.Distance); // B → F (2), F → D (2), total: 4 (or via A if lower)
                Assert.Equal(new List<string> { "B", "F", "D" }, result.Path);
            }

            [Fact]
            public void CalculateShortestPath_SameStartAndEnd_ReturnsZeroDistance()
            {
                // Arrange
                var start = "A";

                // Act
                ShortestPathResult result = _calculator.CalculateShortestPath(start, start);

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
                ShortestPathResult result = _calculator.CalculateShortestPath(start, end);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.Distance);
                Assert.Empty(result.Path);
            }

            [Fact]
            public void CalculateShortestPath_UnreachableNode_ReturnsNegativeOne()
            {
                // Arrange
                var start = "A";
                var end = "Z"; // Assuming Z doesn't exist

                // Act
                ShortestPathResult result = _calculator.CalculateShortestPath(start, end);

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
                ShortestPathResult result = _calculator.CalculateShortestPath(start, end);

                // Assert
                Assert.NotNull(result);
                Assert.True(result.Distance > 0);
                Assert.True(result.Path.Count > 1);
            }
        }
    }

}
