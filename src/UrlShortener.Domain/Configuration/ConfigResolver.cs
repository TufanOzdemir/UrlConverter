using Microsoft.Extensions.Configuration;

namespace UrlShortener.Domain.Configuration
{
    public class ConfigResolver : IConfigResolver
    {
        private readonly IConfiguration _config;
        public ConfigResolver(IConfiguration config)
        {
            _config = config;
        }

        public T Resolve<T>() where T : BaseConfig, new()
        {
            var instance = new T();
            var section = _config.GetSection(instance.ConfigSection);
            section.Bind(instance);
            return instance;
        }
    }
}
