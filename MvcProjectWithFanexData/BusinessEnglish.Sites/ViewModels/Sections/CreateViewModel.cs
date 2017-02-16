namespace BusinessEnglish.Sites.ViewModels.Sections
{
    using Resources;
    using Services.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateViewModel
    {
        [Required]
        [Display(ResourceType = typeof(StringResources), Name = "SectionName")]
        public string Name { get; set; }

        public int TopicId { get; set; }

        public IEnumerable<SelectListItem> Topics { get; set; }
    }
}