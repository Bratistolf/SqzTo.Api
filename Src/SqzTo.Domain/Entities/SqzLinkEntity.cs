using System;

namespace SqzTo.Domain.Entities
{
    public class SqzLinkEntity
    {
        public int SqzLinkEntityId { get; set; }
        public string SqzLink { get; set; }
        public string DestinationUrl { get; set; }
        public int Clicks { get; set; }
        public DateTime Created { get; set; }
    }
}