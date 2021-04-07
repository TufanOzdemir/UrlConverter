using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Domain.Service;

namespace UrlShortener.Application.Query
{
    public class ShortUrlQuery : IRequest<string>
    {
        public string Url { get; set; }
    }

    public class ShortUrlQueryHandler : IRequestHandler<ShortUrlQuery, string>
    {
        private readonly UrlService _urlService;

        public ShortUrlQueryHandler(UrlService urlService)
        {
            _urlService = urlService;
        }

        public Task<string> Handle(ShortUrlQuery request, CancellationToken cancellationToken)
        {
            return _urlService.Shorten(request.Url);
        }
    }
}