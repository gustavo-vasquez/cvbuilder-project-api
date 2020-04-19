using CVBuilder.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Repository
{
    public class CVBuilderDbContext : DbContext
    {
        public CVBuilderDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>().HasData(new Template
            {
                TemplateId = 1,
                Name = "Classic",
                Path = "/img/templates/classic.png"
            }, new Template
            {
                TemplateId = 2,
                Name = "Elegant",
                Path = "/img/templates/elegant.png"
            }, new Template
            {
                TemplateId = 3,
                Name = "Modern",
                Path = "/img/templates/modern.png"
            });
        }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Curriculum> Curriculum { get; set; }
        public DbSet<CustomSection> CustomSections { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }
        public DbSet<PersonalReference> PersonalReferences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
    }
}