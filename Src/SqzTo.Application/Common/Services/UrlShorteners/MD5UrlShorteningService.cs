using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SqzTo.Application.Common.Services.UrlShorteners
{
    // That hash encryption may generate collisions in the DB. We should use counter system for better sustainability!
    public class MD5UrlShorteningService : BaseUrlShorteningService
    {
        public MD5UrlShorteningService(IConfiguration configuration) : base(configuration)
        {
        }

        public override string ShortenUrl(string url)
        {
            var hash = GetMD5Hash(url);
            var joined = LatinBase + NumericBase;

            var sqzLinkBuilder = new StringBuilder();
            for (var i = 0; i < 7; i++)
            {
                sqzLinkBuilder.Append(joined[hash[i]]);
            }

            return sqzLinkBuilder.ToString();
        }

        private byte[] GetMD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                return Base62Convert(hashBytes);
            }
        }

        private byte[] Base62Convert(byte[] source)
        {
            var result = new List<int>();
            int count;
            while ((count = source.Length) > 0)
            {
                var quotient = new List<byte>();
                var remainder = 0;
                for (var i = 0; i != count; i++)
                {
                    int accumulator = source[i] + remainder * 256;
                    byte digit = System.Convert.ToByte((accumulator - (accumulator % 62)) / 62);
                    remainder = accumulator % 62;
                    if (quotient.Count > 0 || digit != 0)
                    {
                        quotient.Add(digit);
                    }
                }

                result.Insert(0, remainder);
                source = quotient.ToArray();
            }

            var output = new byte[result.Count];
            for (var i = 0; i < result.Count; i++)
            {
                output[i] = (byte)result[i];
            }

            return output;
        }
    }
}
