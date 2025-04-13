using SharedLogic.Models;
using SharedLogic.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShortestRouteFinder.Areas.ShortestPath.Controllers
{
    public class jQueryShortestPathController : Controller
    {
        private readonly ShortestPathCalculator _shortestPathCalculator;
        private readonly Dictionary<string, List<RouteLink>> _routeLinks;

        public jQueryShortestPathController()
        {
            _shortestPathCalculator = new ShortestPathCalculator();
            _routeLinks = _shortestPathCalculator.InitializeRouteLinks();
        }

        // GET: ShortestPath/jQueryShortestPath
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string fromNodeName, string toNodeName)
        {
            var result = _shortestPathCalculator.CalculateShortestPath(fromNodeName, toNodeName, _routeLinks);

            return Json(new
            {
                Path = result?.Path,
                Distance = result?.Distance
            });
        }

    }
}