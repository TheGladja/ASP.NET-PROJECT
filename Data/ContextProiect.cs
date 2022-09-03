using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASP.NET_PROJECT.Entities;

namespace ASP.NET_PROJECT.Data
{
    public class ContextProiect : IdentityDbContext<ApplicationUser>
    {
        public ContextProiect(DbContextOptions<ContextProiect> options) : base(options) { }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<ProfessorSchool> ProfessorSchools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DB


            //One to Many

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Students)
                .WithOne(s => s.Professor)
                .HasForeignKey(s => s.ProfessorId);

            //One to One

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Address)
                .WithOne(a => a.Professor);


            //Many to Many

            modelBuilder.Entity<ProfessorSchool>().HasKey(ps => new { ps.ProfessorId, ps.SchoolId });

            modelBuilder.Entity<ProfessorSchool>()
                .HasOne(ps => ps.Professor)
                .WithMany(p => p.ProfessorSchools)
                .HasForeignKey(ps => ps.ProfessorId);

            modelBuilder.Entity<ProfessorSchool>()
                .HasOne(ps => ps.School)
                .WithMany(s => s.ProfessorSchools)
                .HasForeignKey(ps => ps.SchoolId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
