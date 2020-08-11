using System;

namespace SqzTo.Domain.Entities
{
    public class SqzLinkEntity
    {
        public string SqzLink { get; set; }

        public string Domain { get; set; }

        public string Path { get; set; }

        public string DestinationUrl { get; set; }

        public string Description { get; set; }

        public int Clicks { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public DateTime? ExpiringAt { get; set; }
    }
}