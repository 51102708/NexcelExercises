namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class PhraseService : IBaseService<Phrase>
    {
        public void Create(Phrase obj)
        {
            using (EnglishDbContext db = new EnglishDbContext())
            {
                db.Phrases.Add(obj);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var phrase = Get(id);

            if (phrase == null)
            {
                return;
            }

            using (EnglishDbContext db = new EnglishDbContext())
            {
                db.Phrases.Remove(phrase);
                db.SaveChanges();
            }
        }

        public Phrase Get(int id)
        {
            using (EnglishDbContext db = new EnglishDbContext())
            {
                return db.Phrases.Find(id);
            }
        }

        public IEnumerable<Phrase> GetAll()
        {
            using (EnglishDbContext db = new EnglishDbContext())
            {
                return db.Phrases.Include(s => s.Section).OrderBy(x => x.Section.Name);
            }
        }

        public void Update(Phrase obj)
        {
            using (EnglishDbContext db = new EnglishDbContext())
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<Phrase> FilterPhrasesById(IEnumerable<Phrase> phrases, int id)
        {
            return phrases.Where(s => s.Id == id);
        }

        public IEnumerable<Phrase> FilterPhrasesBySectionId(IEnumerable<Phrase> phrases, int sectionId)
        {
            return phrases.Where(s => s.SectionId == sectionId);
        }

        public IEnumerable<Phrase> FilterPhrasesWithName(IEnumerable<Phrase> phrases, string name)
        {
            return phrases.Where(s => s.Name.ToLower().Contains(name.ToLower()));
        }
    }
}