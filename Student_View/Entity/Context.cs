using Microsoft.EntityFrameworkCore;

namespace Student_View.Entity
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>( entity =>
            {
                entity.ToTable("Students");
            });
        }

    }
}
