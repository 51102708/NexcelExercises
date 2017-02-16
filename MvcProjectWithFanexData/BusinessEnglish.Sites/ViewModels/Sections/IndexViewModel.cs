namespace BusinessEnglish.Sites.ViewModels.Sections
{
    using Services.Models;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class IndexViewModel
    {
        public IEnumerable<Section> Sections { get; set; }

        public IEnumerable<SelectListItem> Topics { get; set; }
    }
}