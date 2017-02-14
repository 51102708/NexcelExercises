namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class SectionService : IBaseService<Section>
    {
        public void Create(Section obj)
        {
            using (EnglishDbContext db = new EnglishDbContext())
            {
                db.Sections.Add(obj);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var section = Get(id);

            if (section == null)
            {
                return;
            }

            using (EnglishDbContext db = new EnglishDbContext())
            {
                db.Sections.Remove(section);
                db.SaveChanges();
            }
        }

        public Section Get(int id)
        {
            using (EnglishDbContext db = new EnglishDbContext())
            {
                return db.Sections.Find(id);
            }
        }

        public IEnumerable<Section> GetAll()
        {
            using (EnglishDbContext db = new EnglishDbContext())
            {
                return db.Sections.Include(s => s.Topic).OrderBy(x => x.Topic.Name);
            }
        }

        public void Update(Section obj)
        {
            using (EnglishDbContext db = new EnglishDbContext())
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<Section> FilterSectionsById(IEnumerable<Section> sections, int id)
        {
            return sections.Where(s => s.Id == id);
        }

        public IEnumerable<Section> FilterSectionsByTopicId(IEnumerable<Section> sections, int topicId)
        {
            return sections.Where(s => s.TopicId == topicId);
        }

        public IEnumerable<Section> FilterSectionsWithName(IEnumerable<Section> sections, string name)
        {
            return sections.Where(s => s.Name.ToLower().Contains(name.ToLower()));
        }
    }
}