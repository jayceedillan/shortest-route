using ShortestRouteFinder.Areas.ShortestPath.Controllers;
using ShortestRouteFinder.Models;
using System.Web.Mvc;
using Xunit;

namespace ShortestRouteFinder.Tests.Controllers
{
    public class ShortestPathControllerTests
    {
        [Fact]
        public void Index_Post_ReturnsView_WithValidModel()
        {
            // Arrange
            var controller = new ShortestPathController();
            var fromNode = "A";
            var toNode = "D";

            // Act
            var result = controller.Index(fromNode, toNode) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ShortestPathResultModel>(result.Model);

            var model = (ShortestPathResultModel)result.Model;

            Assert.NotNull(model.Path);
            Assert.True(model.Path.Count > 0);
            Assert.True(model.Distance > 0);
        }

        [Fact]
        public void Index_Post_ReturnsNoPathModel_WhenInvalidNodes()
        {
            // Arrange
            var controller = new ShortestPathController();
            var fromNode = "X";
            var toNode = "Y";

            // Act
            var result = controller.Index(fromNode, toNode) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ShortestPathResultModel>(result.Model);

            var model = (ShortestPathResultModel)result.Model;

            Assert.Empty(model.Path);
            Assert.Equal(-1, model.Distance);
        }
    }
}
