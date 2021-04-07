using Microsoft.AspNetCore.TestHost;
using System;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace UrlShortener.Test
{
    public class UrlIntegrationTest
    {
        private readonly TestServer _testServer;

        public UrlIntegrationTest()
        {
            _testServer = HostBuilderService.Instance.Value.TestServer;
        }

        [Theory]
        [InlineData("https://www.tufan.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064", "tf://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064")]
        [InlineData("https://www.tufan.com/casio/saat-p-1925865?merchantId=105064", "tf://?Page=Product&ContentId=1925865&MerchantId=105064")]
        [InlineData("https://www.tufan.com/casio/erkek-kol-saati-p-1925865", "tf://?Page=Product&ContentId=1925865")]
        [InlineData("https://www.tufan.com/sr?q=elbise", "tf://?Page=Search&Query=elbise")]
        [InlineData("https://www.tufan.com/sr?q=%C3%BCt%C3%BC", "tf://?Page=Search&Query=%C3%BCt%C3%BC")]
        [InlineData("https://www.tufan.com/Hesabim/Favoriler", "tf://?Page=Home")]
        [InlineData("https://www.tufan.com/Hesabim/Siparislerim", "tf://?Page=Home")]
        public async Task ShortenTest(string url, string responseUrl)
        {
            var client = _testServer.CreateClient();
            var escapedRequest = HttpUtility.UrlEncode(url);
            var request = "/api/url/shorten?url=" + escapedRequest;
            var response = await client.GetAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            if (!responseUrl.Equals(result))
            {
                throw new Exception();
            }
        }

        [Theory]
        [InlineData("tf://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064", "https://www.tufan.com/brand/name-p-1925865?boutiqueId=439892&merchantId=105064")]
        [InlineData("tf://?Page=Product&ContentId=1925865&MerchantId=105064", "https://www.tufan.com/brand/name-p-1925865?merchantId=105064")]
        [InlineData("tf://?Page=Product&ContentId=1925865", "https://www.tufan.com/brand/name-p-1925865")]
        [InlineData("tf://?Page=Search&Query=elbise", "https://www.tufan.com/sr?q=elbise")]
        [InlineData("tf://?Page=Search&Query=%C3%BCt%C3%BC", "https://www.tufan.com/sr?q=%C3%BCt%C3%BC")]
        [InlineData("tf://?Page=Favorites", "https://www.tufan.com")]
        [InlineData("tf://?Page=Orders", "https://www.tufan.com")]
        public async Task ExtendTest(string url, string responseUrl)
        {
            var client = _testServer.CreateClient();
            var escapedRequest = HttpUtility.UrlEncode(url);
            var request = "/api/url/extend?url=" + escapedRequest;
            var response = await client.GetAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            if (!responseUrl.Equals(result))
            {
                throw new Exception();
            }
        }
    }
}