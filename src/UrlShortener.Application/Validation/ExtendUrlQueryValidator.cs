using FluentValidation;
using UrlShortener.Application.Query;

namespace UrlShortener.Application.Validation
{
    public class ExtendUrlQueryValidator : AbstractValidator<ExtendUrlQuery>
    {
        public ExtendUrlQueryValidator()
        {
            RuleFor(c => c.Url).NotEmpty().NotNull();
        }
    }
}