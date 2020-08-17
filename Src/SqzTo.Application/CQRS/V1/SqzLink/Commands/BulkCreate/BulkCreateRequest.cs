using MediatR;
using SqzTo.Application.CQRS.V1.SqzLink.Commands.Create;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.BulkCreate
{
    public class BulkCreateRequest : IRequest<BulkCreateResponse>
    {
        [JsonPropertyName("bulk")]
        public IEnumerable<CreateRequest> BulkBody { get; set; }
    }
}
