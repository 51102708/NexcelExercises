using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcProject.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Section> Sections { get; set; }
    }
}