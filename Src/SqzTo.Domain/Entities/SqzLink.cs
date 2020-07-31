using System;

namespace SqzTo.Domain.Entities
{
    public class SqzLink
    {
        public int SqzLinkId { get; set; }
        public string Route { get; set; }
        public string OriginalUrl { get; set; }
        public int Clicks { get; set; }
        public DateTime Created { get; set; }
    }
}