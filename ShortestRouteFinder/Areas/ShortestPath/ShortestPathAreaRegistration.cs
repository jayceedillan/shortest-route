using System.Web.Mvc;

namespace ShortestRouteFinder.Areas.ShortestPath
{
    public class ShortestPathAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ShortestPath";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ShortestPath_default",
                "ShortestPath/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}