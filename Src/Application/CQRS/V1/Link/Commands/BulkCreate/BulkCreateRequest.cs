using MediatR;
using SqzTo.Application.CQRS.V1.Link.Commands.Create;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.Link.Commands.BulkCreate
{
    public class BulkCreateRequest : IRequest<BulkCreateResponse>
    {
        [JsonPropertyName("bulk")]
        public IEnumerable<CreateCommand> BulkBody { get; set; }
    }
}
