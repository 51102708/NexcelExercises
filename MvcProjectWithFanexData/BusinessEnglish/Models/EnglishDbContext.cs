namespace BusinessEnglish.Services.Models
{
    using System.Data.Entity;

    public class EnglishDbContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Phrase> Phrases { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}