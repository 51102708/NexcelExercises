using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessEnglish.Models
{
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