using MediatR;
using SqzTo.Application.Common.Mappings.Interfaces;
using SqzTo.Domain.Entities;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Create
{
    /// <summary>
    /// Request DTO for the POST:v1.0/sqzlink/ route.
    /// </summary>
    public partial class CreateRequest : IRequest<CreateResponce>, IMapTo<SqzLinkEntity>
    {
        /// <summary>
        /// SqzLink's domain name.
        /// </summary>
        /// <example>sqz.to</example>
        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// SqzLink's destination URL.
        /// </summary>
        [JsonPropertyName("destination_url")]
        public string DestinationUrl { get; set; }
    }
}
