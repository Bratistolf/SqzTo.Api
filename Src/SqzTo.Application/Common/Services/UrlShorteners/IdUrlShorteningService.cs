using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System.Text;

namespace SqzTo.Application.Common.Services.UrlShorteners
{
    public class IdUrlShorteningService : IUrlShorteningService
    {
        private readonly string Base62 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        public string ShortenUrl(ShortUrl url)
        {
            var id = url.ShortUrlId;
            var route = new StringBuilder();

            for (var i = 0; i < 7; i++)
            {
                var temp = id % Base62.Length;
                route.Append(Base62[temp]);
                id = (id / Base62.Length);
            }

            return route.ToString();
        }
    }
}
