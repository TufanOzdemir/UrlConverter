using System.Threading.Tasks;
using UrlShortener.Domain.Port;
using UrlShortener.Domain.UrlModule;

namespace UrlShortener.Domain.Service
{
    public class UrlService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IUrlCreator _urlCreator;

        public UrlService(IUrlRepository urlRepository, IUrlCreator urlCreator)
        {
            _urlRepository = urlRepository;
            _urlCreator = urlCreator;
        }

        public Task<string> Shorten(string url)
        {
            var shortUrl = _urlRepository.Get(url);
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                shortUrl = _urlCreator.Create(url, Model.Const.DataType.LongToShort);
                _urlRepository.Create(url, shortUrl);
            }
            return Task.FromResult(shortUrl);
        }

        public Task<string> Extend(string url)
        {
            var extendUrl = _urlRepository.Get(url);
            if (string.IsNullOrWhiteSpace(extendUrl))
            {
                extendUrl = _urlCreator.Create(url, Model.Const.DataType.ShortToLong);
                _urlRepository.Create(url, extendUrl);
            }
            return Task.FromResult(extendUrl);
        }
    }
}