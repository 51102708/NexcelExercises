namespace BusinessEnglish.Sites.ViewModels
{
    using Services.Models;
    using System.Collections.Generic;

    public class BaseViewModel
    {
        public IEnumerable<Topic> Topics { get; set; }

        public Section CurrentSection { get; set; }

        public int CurrentTopicId { get; set; }

        public int CurrentSectionId { get; set; }
    }
}