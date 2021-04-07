namespace UrlShortener.Domain.Model.Const
{
    public class ConstVariables
    {
        public struct Logging
        {
            public const string ConfigPath = @"App_Config\nlog.config";
        }

        public struct Caching
        {
            public const string CommonCacheConfigurationKey = "CommonCache";
            public const string LongDurationMemoryConfigurationKey = "LongDurationCache";
            public const string SmallDurationCacheConfigurationKey = "SmallDurationCache";
            public const string UrlKeyCache = "Url_Key";
            public const string UrlValueCache = "Url_Value";
        }
    }

    public enum DataType
    {
        LongToShort,
        ShortToLong
    }
}