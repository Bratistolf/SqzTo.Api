using System;

namespace SqzTo.Domain.Entities
{
    public class ShortUrl
    {
        public int ShortUrlId { get; set; }
        public string Route { get; set; }
        public string OriginalUrl { get; set; }
        public int Clicks { get; set; }
        public DateTime Created { get; set; }
    }
}