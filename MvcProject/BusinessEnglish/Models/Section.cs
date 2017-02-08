using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessEnglish.Models
{
    public class Section
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Section Name")]
        public string Name { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public IEnumerable<Pharse> Pharses { get; set; }
    }
}