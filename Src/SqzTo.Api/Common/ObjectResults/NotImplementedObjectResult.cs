using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SqzTo.Api.Common.ObjectResults
{
    public class NotImplementedObjectResult : ObjectResult
    {
        /// <summary>
        /// Creates a new NotImplementedObjectResult instance.
        /// </summary>
        /// <param name="value">The value to format in the entity body.</param>
        public NotImplementedObjectResult([ActionResultObjectValue] object value) : base(value)
        {
            // Sets the HTTP status code 501 (Not Implemented).
            // https://tools.ietf.org/html/rfc7231#section-6.6.2
            StatusCode = StatusCodes.Status501NotImplemented;
        }
    }
}
