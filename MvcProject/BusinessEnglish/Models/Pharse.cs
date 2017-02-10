namespace BusinessEnglish.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Pharse
    {
        public int Id { get; set; }

        [Display(Name = "Pharse")]
        public string Name { get; set; }

        [Required]
        public string Example { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}