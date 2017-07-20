using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skAleUP.Common.Entities.WebUtils
{
    public class WebElementStatistic
    {
        public Guid Id { get; set; }
        public WebElement WebElement { get; set; }
        
        public bool SearchRank { get; set; }

    }
}
