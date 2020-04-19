using CVBuilder.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Repository
{
    public class CVBuilderDbContext : DbContext
    {
        public CVBuilderDbContext(DbContextOptions options) : base(options)
        {
            
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