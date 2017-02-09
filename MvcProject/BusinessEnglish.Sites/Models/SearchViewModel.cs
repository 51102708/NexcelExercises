using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessEnglish.Sites.Models
{
    public class SearchViewModel
    {
        public int ResultLength { get; set; }

        public string SearchString { get; set; }

        public string SearchType { get; set; }
    }
}