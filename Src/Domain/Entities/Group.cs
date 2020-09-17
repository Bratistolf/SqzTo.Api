using System.Collections.Generic;

namespace SqzTo.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Domain { get; set; }

        public string Description { get; set; }

        public string GroupPictureUrl { get; set; }

        public ICollection<SqzLink> SqzLinks { get; private set; }

        public Group()
        {
            SqzLinks = new HashSet<SqzLink>();
        }
    }
}
