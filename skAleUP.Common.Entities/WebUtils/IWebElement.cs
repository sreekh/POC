using System;

namespace skAleUP.Common.Entities.WebUtils
{
    public interface IWebElement
    {
        DateTime Created { get; set; }
        Guid Id { get; set; }
        bool IsAccessible { get; set; }
        DateTime LastCrawled { get; set; }
        DateTime LastScraped { get; set; }
        DateTime LastUpdated { get; set; }
        string Title { get; set; }
        string Url { get; set; }
    }
}