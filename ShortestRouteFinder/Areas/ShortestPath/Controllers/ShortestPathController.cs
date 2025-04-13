using SharedLogic.Models;
using SharedLogic.Services;
using ShortestRouteFinder.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShortestRouteFinder.Areas.ShortestPath.Controllers
{
    public class ShortestPathController : Controller
    {
        private readonly ShortestPathCalculator _shortestPathCalculator;
        private readonly Dictionary<string, List<RouteLink>> _routeLinks;

        public ShortestPathController()
        {
            _shortestPathCalculator = new ShortestPathCalculator();
            _routeLinks = _shortestPathCalculator.InitializeRouteLinks();
        }

        // GET: ShortestPath/ShortestPath
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string fromNodeName, string toNodeName)
        {
            var result = _shortestPathCalculator.CalculateShortestPath(fromNodeName, toNodeName, _routeLinks);
            
            var model = new ShortestPathResultModel
            {
                Path = result?.Path ?? new List<string>(),
                Distance = result?.Distance ?? -1,
            };

            return View(model);
        }
    }
}