namespace BusinessEnglish.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class EnglishDbContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Phrase> Phrases { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}