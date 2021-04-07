using UrlShortener.Domain.Model.Const;

namespace UrlShortener.Domain.UrlModule
{
    public interface IUrlCreator
    {
        string Create(string key, DataType type);
    }
}