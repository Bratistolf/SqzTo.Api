using Domain.Common;
using System;

namespace SqzTo.Domain.Entities
{
    public class SqzLink : IHasTracking
    {
        public string Id { get; set; }

        public string Domain { get; set; }

        public string Key { get; set; }

        public string Link => $"https://{Domain}/{Key}";

        public string DestinationUrl { get; set; }

        public string Description { get; set; }

        public int Clicks { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public DateTime? ExpiringAt { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }
    }
}