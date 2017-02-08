namespace BusinessEnglish.Services
{
    using Models;
    using MvcProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TopicService
    {
        private EnglishDbContext db = new EnglishDbContext();

        public TopicService()
        {
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            var topics = (from d in db.Topics
                          orderby d.Id
                          select d).ToList();

            foreach (var topic in topics)
            {
                var sections = db.Sections.Include(s => s.Topic).Where(x => x.TopicId == topic.Id).ToList();
                topic.Sections = sections;
            }

            return topics;
        }
    }
}