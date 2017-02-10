namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Data.Entity;

    public class TopicService : IBaseService
    {
        private EnglishDbContext db = new EnglishDbContext();

        public void Create(object obj)
        {
            db.Topics.Add((Topic)obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
        }

        public object Get(int id)
        {
            return db.Topics.Where(x => x.Id == id).ToList();
        }

        public IEnumerable<object> GetAll()
        {
            var topics = (IEnumerable<Topic>)db.Topics.OrderBy(x => x.Id).ToList();

            foreach (var topic in topics)
            {
                var sections = (IEnumerable<Section>)db.Sections.Include(s => s.Topic).Where(x => x.TopicId == topic.Id).ToList();
                topic.Sections = sections;
            }

            return topics;
        }

        public void Update(object obj)
        {
            db.Entry((Topic)obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<object> FilterTopicsWithName(IEnumerable<Topic> topics, string name)
        {
            return topics.Where(s => s.Name.ToLower().Contains(name.ToLower()));
        }
    }
}