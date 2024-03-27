using Microsoft.EntityFrameworkCore;

namespace BlazorForms.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Location> Location { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student & Location One to Many
            modelBuilder.Entity<Student>()
                    .HasOne(e => e.Location_R)
                    .WithMany(e => e.Student_R)
                    .HasForeignKey(e => e.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);

            // Student & School One to Many
            modelBuilder.Entity<Student>()
                    .HasOne(e => e.School_R)
                    .WithMany(e => e.Student_R)
                    .HasForeignKey(e => e.SchoolId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
