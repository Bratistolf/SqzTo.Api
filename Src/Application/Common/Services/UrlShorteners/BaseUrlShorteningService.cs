using Microsoft.Extensions.Configuration;
using SqzTo.Application.Common.Interfaces;

namespace SqzTo.Application.Common.Services.UrlShorteners
{
    public abstract class BaseUrlShorteningService : IUrlShorteningService
    {
        protected readonly string NumericBase   = "0123456789";
        protected readonly string LatinBase     = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        protected readonly string CyrillicBase  = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        private readonly IConfiguration _configuration;

        public BaseUrlShorteningService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public abstract string ShortenUrl(string url);

        protected string BuildSqzLink(string path)
        {
            var domains = _configuration.GetSection("Domains");
            string domain;

            if (_configuration.GetValue<bool>("UseLocalDomain"))
            {
                domain = domains.GetValue<string>("Local");
            }
            else
            {
                domain = domains.GetValue<string>("Latin");
            }

            return path;
        }
    }
}
