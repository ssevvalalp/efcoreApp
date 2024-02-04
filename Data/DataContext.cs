using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>(); //initilized/ = null!;
        public DbSet<Student> Students => Set<Student>();
        public DbSet<CourseRegistration> CourseRegistrations => Set<CourseRegistration>();

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


    }

    //code first => entity,dbcontect => database (sqlite)
    //database first
}
