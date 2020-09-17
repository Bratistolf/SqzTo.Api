using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.Link.Queries.GetSqzLinkQr
{
    public class GetSqzLinkQrDto
    {
        [JsonPropertyName("qr_code")]
        public string QrCode { get; set; }

        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
