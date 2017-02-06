using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class BaseViewModel
    {
        public IEnumerable<Topic> Topics { get; set; }
        public Section CurrentSection { get; set; }

        public int CurrentTopicId { get; set; }
        public int CurrentSectionId { get; set; }
    }
}