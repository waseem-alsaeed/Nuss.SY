using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int DID { get; set; }
  //      public DateTime CreatedDate { get; set; }
        public bool IsMain { get; set; }

        public string VideoUrl { get; set; }
    }

    public class AllNews : News
    {
        public string DName { get; set; }
    }
}
