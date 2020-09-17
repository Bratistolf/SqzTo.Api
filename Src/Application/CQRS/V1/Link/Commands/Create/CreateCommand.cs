using MediatR;
using SqzTo.Application.Common.Mappings.Interfaces;
using SqzTo.Common;
using SqzTo.Domain.Entities;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Create
{
    /// <summary>
    /// Request DTO for the POST:v1.0/sqzlink/ route.
    /// </summary>
    public partial class CreateCommand : IRequest<SqzLinkDto>, IMapTo<SqzLink>
    {
        /// <summary>
        /// SqzLink's domain name.
        /// </summary>
        /// <example>sqz.to</example>
        /// <remarks>Team implementation.</remarks>
        [JsonPropertyName("domain")]
        public string Domain { get; set; } = Constants.DefaultDomain;

        /// <summary>
        /// SqzLink's destination URL.
        /// </summary>
        [JsonPropertyName("destination_url")]
        public string DestinationUrl { get; set; }
    }
}
