namespace BusinessEnglish.Sites.Models
{
    using System.Collections.Generic;

    public class HomeViewModel : BaseViewModel
    {
        public SearchResultModel CurrentSearch { get; set; }
    }

    public class SearchResultModel
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