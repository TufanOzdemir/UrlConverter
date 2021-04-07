using FluentValidation;
using UrlShortener.Application.Query;

namespace UrlShortener.Application.Validation
{
    public class ShortUrlQueryValidator : AbstractValidator<ShortUrlQuery>
    {
        public ShortUrlQueryValidator()
        {
            RuleFor(c => c.Url).NotEmpty().NotNull();
        }
    }
}