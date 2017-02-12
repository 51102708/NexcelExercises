namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class PharseService : IBaseService<Pharse>
    {
        private EnglishDbContext db = new EnglishDbContext();

        public void Create(Pharse obj)
        {
            db.Pharses.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var pharse = Get(id);
            if (pharse == null)
            {
                return;
            }
            db.Pharses.Remove(pharse);
            db.SaveChanges();
        }

        public Pharse Get(int id)
        {
            return db.Pharses.Find(id);
        }

        public IEnumerable<Pharse> GetAll()
        {
            return db.Pharses.Include(s => s.Section).OrderBy(x => x.Section.Name);
        }

        public void Update(Pharse obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Pharse> FilterPharsesById(IEnumerable<Pharse> pharses, int id)
        {
            return pharses.Where(s => s.Id == id);
        }

        public IEnumerable<Pharse> FilterPharsesBySectionId(IEnumerable<Pharse> pharses, int sectionId)
        {
            return pharses.Where(s => s.SectionId == sectionId);
        }

        public IEnumerable<Pharse> FilterPharsesWithName(IEnumerable<Pharse> pharses, string name)
        {
            return pharses.Where(s => s.Name.ToLower().Contains(name.ToLower()));
        }
    }
}