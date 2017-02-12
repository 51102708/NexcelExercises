namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class SectionService : IBaseService<Section>
    {
        private EnglishDbContext db = new EnglishDbContext();

        public void Create(Section obj)
        {
            db.Sections.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var section = Get(id);

            if (section == null)
            {
                return;
            }

            db.Sections.Remove(section);
            db.SaveChanges();
        }

        public Section Get(int id)
        {
            return db.Sections.Find(id);
        }

        public IEnumerable<Section> GetAll()
        {
            return db.Sections.Include(s => s.Topic).OrderBy(x => x.Topic.Name);
        }

        public void Update(Section obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
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