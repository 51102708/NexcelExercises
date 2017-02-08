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
        public DbSet<Pharse> Pharses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EnglishDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}