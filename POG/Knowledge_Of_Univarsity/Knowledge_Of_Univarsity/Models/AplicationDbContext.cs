using Microsoft.EntityFrameworkCore;

namespace Knowledge_Of_Univarsity.Models
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<SuccessStory> SuccessStories { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<College> Colleges { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> option) : base(option)
        {

        }
    }
}
