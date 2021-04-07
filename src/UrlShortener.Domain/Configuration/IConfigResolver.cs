namespace UrlShortener.Domain.Configuration
{
    public interface IConfigResolver
    {
        T Resolve<T>() where T : BaseConfig, new();
    }
}