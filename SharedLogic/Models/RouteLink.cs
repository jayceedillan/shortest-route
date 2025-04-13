namespace SharedLogic.Models
{
    public class RouteLink
    {
        public string To { get; set; }
        public int Distance { get; set; }
      
        public RouteLink(string to, int distance)
        {
            To = to;
            Distance = distance;
        }
    }
}
