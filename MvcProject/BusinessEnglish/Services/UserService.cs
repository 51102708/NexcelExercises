namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class UserService : IBaseService<User>
    {
        private EnglishDbContext db = new EnglishDbContext();

        public void Create(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);

            if (user == null)
            {
                return;
            }

            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User Get(string userName)
        {
            var users = db.Users.Where(s => s.UserName.ToLower().Contains(userName.ToLower()));

            if (users.Count() > 0)
            {
                return users.ToList().First();
            }

            return null;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.Include(s => s.UserRole).OrderBy(x => x.UserRole.RoleName);
        }

        public IEnumerable<UserRole> GetAllRoles()
        {
            return db.UserRoles.OrderBy(x => x.Id);
        }

        public void Update(User obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}