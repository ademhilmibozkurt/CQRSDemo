using Microsoft.EntityFrameworkCore;

namespace CqrsDemo.Data
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions<StudentContext> context) : base(context)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student(){Id = 1, Age = 16, FirstName = "Yaren", LastName = "Kızılay"},
                new Student(){Id = 2, Age = 14, FirstName = "Mehmet", LastName = "Kastor"},
                new Student(){Id = 3, Age = 17, FirstName = "Musa Engin", LastName = "Çelenk"},
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
