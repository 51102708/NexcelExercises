namespace BusinessEnglish.Services.Models
{
    using Resources;
    using System.ComponentModel.DataAnnotations;

    public class Phrase
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(StringResources), Name = "PhraseName")]
        public string Name { get; set; }

        [Required]
        public string Example { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}