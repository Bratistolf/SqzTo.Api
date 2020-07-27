using SqzTo.Domain.Entities;

namespace SqzTo.Application.Common.Interfaces
{
    public interface IUrlShorteningService
    {
        string ShortenUrl(ShortUrl url);
    }
}
