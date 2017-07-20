namespace skAleUP.Common.Entities.WebUtils
{
    public class WebDocument : WebElement
    {
        public bool IsLeaf { get; set; }
        public int TotalLinks { get; set; }
        public int TotalMedia { get; set; }
    }
}
