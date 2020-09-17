using System;

namespace Domain.Common
{
    public interface IHasTracking
    {
        int? CreatedBy { get; set; }
        DateTime Created { get; set; }
        int? LastModifiedBy { get; set; }
        DateTime? LastModified { get; set; }
    }
}
