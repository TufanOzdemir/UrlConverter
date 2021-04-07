namespace UrlShortener.Domain.Port
{
    public interface IRepository<T>
    {
        T Create(string key, T model);
        T Get(string key);
    }
}