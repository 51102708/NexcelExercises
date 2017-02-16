namespace BusinessEnglish.Sites.ViewModels.Phrases
{
    using Services.Models;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class IndexViewModel
    {
        public IEnumerable<Phrase> Phrases { get; set; }

        public IEnumerable<SelectListItem> Sections { get; set; }
    }
}