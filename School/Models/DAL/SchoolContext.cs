using School.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace School

{
    public class SchoolContext : DbContext
    {   
        public SchoolContext()
        {

        }
        protected readonly IConfiguration Configuration;
        public SchoolContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            //options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            options.UseNpgsql("Server=localhost; Database=schooldb; Username=postgres; Password=postgres ");
            //options.LogTo(Console.WriteLine);
            options.LogTo(message => Debug.WriteLine(message));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            //make both foreign keys a primary key in the join table (Grade)
            modelBuilder.Entity<Grade>().HasKey(sc => new { sc.StudentId, sc.SubjectId });
            modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId);
            modelBuilder.Entity<Grade>()
            .HasOne(g => g.Subject)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.SubjectId);
            modelBuilder.Entity<AcademicYearSubject>().HasKey(sc => new { sc.AcademicYearId, sc.SubjectId });
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<AcademicYear> AcademicYear { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Grade> Grade { get; set; }




    }
}
