namespace BusinessEnglish.Sites.ViewModels.Phrases
{
    using Resources;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateViewModel
    {
        [Display(ResourceType = typeof(StringResources), Name = "PhraseName")]
        public string Name { get; set; }

        [Required]
        public string Example { get; set; }

        public int SectionId { get; set; }

        public IEnumerable<SelectListItem> Sections { get; set; }
    }
}