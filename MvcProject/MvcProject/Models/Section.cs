using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public IEnumerable<Pharse> Pharses { get; set; }
    }
}