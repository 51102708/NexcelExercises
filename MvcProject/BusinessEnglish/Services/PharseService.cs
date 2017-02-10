namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class PharseService : IBaseService
    {
        private EnglishDbContext db = new EnglishDbContext();

        public void Create(object obj)
        {
            db.Pharses.Add((Pharse)obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Pharses.Remove((Pharse)Get(id));
            db.SaveChanges();
        }

        public object Get(int id)
        {
            return db.Pharses.Find(id);
        }

        public IEnumerable<object> GetAll()
        {
            return db.Pharses.Include(s => s.Section);
        }

        public void Update(object obj)
        {
            db.Entry((Pharse)obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<object> FilterPharsesById(IEnumerable<Pharse> pharses, int id)
        {
            return pharses.Where(s => s.Id == id);
        }

        public IEnumerable<object> FilterPharsesBySectionId(IEnumerable<Pharse> pharses, int sectionId)
        {
            return pharses.Where(s => s.SectionId == sectionId);
        }

        public IEnumerable<object> FilterPharsesWithName(IEnumerable<Pharse> pharses, string name)
        {
            return pharses.Where(s => s.Name.ToLower().Contains(name.ToLower()));
        }
    }
}