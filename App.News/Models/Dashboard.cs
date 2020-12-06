using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.News.Models
{
    public class Dashboard
    {
        public List<App.Models.News> lstNews { get; set; }
        public List<App.Models.News> IsMain { get; set; }

    }
}