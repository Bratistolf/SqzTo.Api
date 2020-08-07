using Microsoft.AspNetCore.Identity;
using System;

namespace SqzTo.Infrastructure.Identity
{
    public class SqzToUser : IdentityUser<Guid>
    {
        public string ProfileImg { get; set; }
    }
}
