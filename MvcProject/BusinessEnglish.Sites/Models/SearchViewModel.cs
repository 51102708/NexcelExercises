using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessEnglish.Sites.Models
{
    public class SearchViewModel
    {
        public int ResultLength { get; set; }

        public IList<ResultData> ResultDatas { get; set; }

        public string SearchString { get; set; }

        public string SearchType { get; set; }
    }

    public class ResultData
    {
        public string ResultTitle { get; set; }

        public string ResultContent { get; set; }

        public int SectionId { get; set; }
        public int TopicId { get; set; }
    }
}