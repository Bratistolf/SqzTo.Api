using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Navigate
{
    public class NavigateCommand : IRequest<NavigateDto>
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
