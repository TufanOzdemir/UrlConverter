using FluentValidation;
using UrlShortener.Domain.Model.Config;

namespace UrlShortener.Domain.UrlModule
{
    public class UrlShortToLongConvert : IUrlConverter
    {
        private readonly UrlConfig _urlConfig;

        public UrlShortToLongConvert(UrlConfig urlConfig)
        {
            _urlConfig = urlConfig;
        }

        public string Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ValidationException("url boş geçilemez");
            }
            var result = "";

            var logicalString = source.Split('?')[1];
            var splitedLogicalString = logicalString.Split('&');

            if (splitedLogicalString[0].Equals(_urlConfig.PageSearch))
                result = ConvertFromSearch(splitedLogicalString[1]);
            else if (splitedLogicalString[0].Equals(_urlConfig.PageProduct))
                result = ConvertFromProductDetail(splitedLogicalString);
            else
                result = ConvertFromPage();

            return result;
        }

        private string ConvertFromPage()
        {
            return _urlConfig.LongBaseUrl;
        }

        private string ConvertFromProductDetail(string[] splitedLogicalString)
        {
            string productId = splitedLogicalString[1].Split('=')[1];

            var result = string.Concat(
                _urlConfig.LongBaseUrl,
                _urlConfig.ShortToLong.ProductDetailStandartUrl,
                _urlConfig.LongToShort.ProductSeperateKeyword,
                productId);

            if (splitedLogicalString.Length > 2)
            {
                result = string.Concat(result, "?");
                string value = "";
                for (int i = 2; i < splitedLogicalString.Length; i++)
                {
                    value = splitedLogicalString[i].Replace(_urlConfig.LongToShort.AfterCustomReplaceValue, _urlConfig.LongToShort.BeforeCustomReplaceValue);
                    value = value.Replace(_urlConfig.LongToShort.AfterReplaceValue, _urlConfig.LongToShort.BeforeReplaceValue);
                    result = i == 2 ? string.Concat(result, value) : string.Concat(result, "&", value);
                }
            }
            return result;
        }

        private string ConvertFromSearch(string splitedLogicalString)
        {
            var query = splitedLogicalString.Split('=')[1];
            return string.Concat(
                _urlConfig.LongBaseUrl,
                _urlConfig.LongToShort.SearchSeperateKeyword,
                "?q=",
                query);
        }
    }
}