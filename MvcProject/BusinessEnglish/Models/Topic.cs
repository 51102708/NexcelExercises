namespace BusinessEnglish.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Topic
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }

        public IEnumerable<Section> Sections { get; set; }
    }
}