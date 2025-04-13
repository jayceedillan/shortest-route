using System.Collections.Generic;

namespace ShortestRouteFinder.Models
{
    public class ShortestPathResultModel
    {
        public List<string> Path { get; set; }
        public int Distance { get; set; }
    }
}