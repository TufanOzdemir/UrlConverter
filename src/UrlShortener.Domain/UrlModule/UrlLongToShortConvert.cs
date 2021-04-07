using System;
using System.Linq;
using UrlShortener.Domain.Model.Config;

namespace UrlShortener.Domain.UrlModule
{
    public class UrlLongToShortConvert : IUrlConverter
    {
        private readonly UrlConfig _urlConfig;

        public UrlLongToShortConvert(UrlConfig urlConfig)
        {
            _urlConfig = urlConfig;
        }

        public string Convert(string source)
        {
            string result = "";
            var request = new Uri(source);

            if (request.AbsolutePath.Equals(_urlConfig.LongToShort.SearchSeperateKeyword))
                result = ConvertFromSearch(request);
            else if (request.AbsolutePath.Contains(_urlConfig.LongToShort.ProductSeperateKeyword))
                result = ConvertFromProductDetail(request);
            else
                result = ConvertFromPage();

            return result;
        }

        private string ConvertFromSearch(Uri request)
        {
            var query = request.Query.Split('=');
            return string.Concat(
                _urlConfig.ShortBaseUrl,
                "?",
                _urlConfig.PageSearch,
                "&",
                _urlConfig.LongToShort.ResponseSearchQuery,
                "=",
                query.Last());
        }

        private string ConvertFromPage()
        {
            return string.Concat(
                _urlConfig.ShortBaseUrl,
                "?",
                _urlConfig.PageHome);
        }

        private string ConvertFromProductDetail(Uri request)
        {
            var firstSplit = request.AbsolutePath.Split("-p-");
            var secondSplit = !string.IsNullOrWhiteSpace(request.Query) ? request.Query.Split('&') : null;
            var result = string.Concat(
                _urlConfig.ShortBaseUrl,
                "?",
                _urlConfig.PageProduct,
                "&",
                _urlConfig.LongToShort.MainIdName,
                "=",
                firstSplit.Last());
            if (secondSplit != null)
            {
                var value = "";
                foreach (var item in secondSplit)
                {
                    value = item.Replace("?", "");
                    value = value.Replace(_urlConfig.LongToShort.BeforeCustomReplaceValue, _urlConfig.LongToShort.AfterCustomReplaceValue);
                    value = value.Replace(_urlConfig.LongToShort.BeforeReplaceValue, _urlConfig.LongToShort.AfterReplaceValue);
                    result = string.Concat(result, "&", value);
                }
            }
            return result;
        }
    }
}