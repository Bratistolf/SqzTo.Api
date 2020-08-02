using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.CreateSqzLink
{
    public partial class CreateSqzLinkCommand : IRequest<CreateSqzLinkDto>
    {
        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("destination_url")]
        public string DestinationUrl { get; set; }
    }
}
