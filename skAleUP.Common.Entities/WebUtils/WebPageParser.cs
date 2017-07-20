using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace skAleUP.Common.Entities.WebUtils
{
    public class WebPageParser
    {
        HttpClient httpClient;
        List<WebLink> pageLinks;
        public List<WebLink> PageLinks { get => pageLinks; set => pageLinks = value; }
        public async Task GetAllLinks(string pageUrl)
        {
            PrepareHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(pageUrl);
            if (response.IsSuccessStatusCode)
            {
                var pageResponseStream = await response.Content.ReadAsStreamAsync();
                using (StreamReader sr = new StreamReader(pageResponseStream))
                {
                    PageLinks = GetAllLinksFromPage(await sr.ReadToEndAsync(), pageUrl);
                }
            }
        }
        private List<WebLink> GetAllLinksFromPage(String pageContent, string pageUrl)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageContent);

            var tds = from td in htmlDocument.DocumentNode.SelectNodes("//a[@href]")
                      select new WebLink
                      {
                          BaseUrl = pageUrl,
                          Id = Guid.NewGuid(),
                          Created = DateTime.UtcNow,
                          LastUpdated = DateTime.UtcNow,
                          RelativeUrl = td.Attributes["href"].Value,
                          Title = td.InnerText
                      };


            return tds.ToList();
        }
        private void PrepareHttpClient()
        {
            httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }, true);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
