namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class SectionService : IBaseService
    {
        private EnglishDbContext db = new EnglishDbContext();

        public void Create(object obj)
        {
            db.Sections.Add((Section)obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Sections.Remove((Section)Get(id));
            db.SaveChanges();
        }

        public object Get(int id)
        {
            return db.Sections.Find(id);
        }

        public IEnumerable<object> GetAll()
        {
            return db.Sections.Include(s => s.Topic);
        }

        public void Update(object obj)
        {
            db.Entry((Section)obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<object> FilterSectionsById(IEnumerable<Section> sections, int id)
        {
            return sections.Where(s => s.Id == id);
        }

        public IEnumerable<object> FilterSectionsByTopicId(IEnumerable<Section> sections, int topicId)
        {
            return sections.Where(s => s.TopicId == topicId);
        }

        public IEnumerable<object> FilterSectionsWithName(IEnumerable<Section> sections, string name)
        {
            return sections.Where(s => s.Name.ToLower().Contains(name.ToLower()));
        }
    }
}