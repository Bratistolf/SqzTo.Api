﻿using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Navigate
{
    public class NavigateRequest : IRequest<NavigateResponse>
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
