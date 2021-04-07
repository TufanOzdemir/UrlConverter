namespace UrlShortener.Domain.UrlModule
{
    public interface IUrlConverter
    {
        string Convert(string source);
    }
}