namespace BusinessEnglish.Services.Models
{
    using Resources;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Section
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof(StringResources), Name = "SectionName")]
        public string Name { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public IEnumerable<Phrase> Phrases { get; set; }
    }
}