﻿using System;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Edit
{
    public class EditCommandBody
    {
        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("expiring_at")]
        public DateTime ExpiringAt { get; set; }
    }
}
