using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Domain.Service;

namespace UrlShortener.Application.Query
{
    public class ExtendUrlQuery : IRequest<string>
    {
        public string Url { get; set; }
    }

    public class ExtendUrlQueryHandler : IRequestHandler<ExtendUrlQuery, string>
    {
        private readonly UrlService _urlService;

        public ExtendUrlQueryHandler(UrlService urlService)
        {
            _urlService = urlService;
        }

        public Task<string> Handle(ExtendUrlQuery request, CancellationToken cancellationToken)
        {
            return _urlService.Extend(request.Url);
        }
    }
}