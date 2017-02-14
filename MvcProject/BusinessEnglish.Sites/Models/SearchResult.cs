namespace BusinessEnglish.Sites.Models
{
    using System.Collections.Generic;

    public class SearchResult
    {
        public int ResultLength { get; set; }

        public IList<SearchResultData> ResultData { get; set; }

        public string SearchString { get; set; }

        public string SearchType { get; set; }
    }
}