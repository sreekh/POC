using System;

namespace skAleUP.Common.Entities.WebUtils
{
    public abstract class WebElement : IWebElement
    {
        public Guid Id { get; set; }
        public virtual string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsAccessible { get; set; }
        public string Title { get; set; }
        public DateTime LastCrawled { get; set; }
        public DateTime LastScraped { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() is IWebElement)
                return ((IWebElement)obj).Id == this.Id;
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            if(this.Id != null)
                return this.Id.GetHashCode();
            else
                return base.GetHashCode();
        }
    }
}
