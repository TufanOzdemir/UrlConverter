using System;
using UrlShortener.Domain.Configuration;
using UrlShortener.Domain.Model.Config;
using UrlShortener.Domain.Model.Const;

namespace UrlShortener.Domain.UrlModule
{
    public class UrlCreator : IUrlCreator
    {
        private readonly UrlConfig _urlConfig;

        public UrlCreator(IConfigResolver configResolver)
        {
            _urlConfig = configResolver.Resolve<UrlConfig>();
        }

        public string Create(string key, DataType type)
        {
            IUrlConverter converter = null;
            switch (type)
            {
                case DataType.LongToShort:
                    converter = new UrlLongToShortConvert(_urlConfig);
                    break;
                case DataType.ShortToLong:
                    converter = new UrlShortToLongConvert(_urlConfig);
                    break;
                default:
                    break;
            }
            return converter.Convert(key);
        }
    }
}
