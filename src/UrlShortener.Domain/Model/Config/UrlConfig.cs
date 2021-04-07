using UrlShortener.Domain.Configuration;

namespace UrlShortener.Domain.Model.Config
{
    public class UrlConfig : BaseConfig
    {
        public LongToShortConfig LongToShort { get; set; }
        public ShortToLongConfig ShortToLong { get; set; }
        public string LongBaseUrl { get; set; }
        public string ShortBaseUrl { get; set; }
        public string PageSearch { get; set; }
        public string PageProduct { get; set; }
        public string PageHome { get; set; }
        public override string ConfigSection => "UrlScheme";
    }

    public class LongToShortConfig : BaseConfig
    {
        public string SearchSeperateKeyword { get; set; }
        public string ProductSeperateKeyword { get; set; }
        public string ResponseSearchQuery { get; set; }
        public string MainIdName { get; set; }
        public string BeforeReplaceValue { get; set; }
        public string AfterReplaceValue { get; set; }
        public string BeforeCustomReplaceValue { get; set; }
        public string AfterCustomReplaceValue { get; set; }

        public override string ConfigSection => "LongToShort";
    }

    public class ShortToLongConfig : BaseConfig
    {
        public string ProductDetailStandartUrl { get; set; }
        public override string ConfigSection => "ShortToLong";
    }
}