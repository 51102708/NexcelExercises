using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }

        public IEnumerable<Section> Sections { get; set; }
    }
}