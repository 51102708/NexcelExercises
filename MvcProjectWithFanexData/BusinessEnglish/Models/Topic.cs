namespace BusinessEnglish.Services.Models
{
    using Resources;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Topic
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof(StringResources), Name = "TopicName")]
        public string Name { get; set; }

        public IEnumerable<Section> Sections { get; set; }
    }
}