using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class Pharse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Example { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}