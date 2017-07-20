using skAleUP.Common.Entities.WebUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skAleUP.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://download.goldenbiaro.com/index.php?dir=Audio/The%20Corrs/";
            WebPageParser parser = new WebPageParser();
            var task = parser.GetAllLinks(url);
            task.Wait();
            parser.PageLinks.ForEach(l => Console.WriteLine(l));

            Console.ReadLine();
        }
    }
}
