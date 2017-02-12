namespace BusinessEnglish.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Phrase
    {
        public int Id { get; set; }

        [Display(Name = "Phrase")]
        public string Name { get; set; }

        [Required]
        public string Example { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}