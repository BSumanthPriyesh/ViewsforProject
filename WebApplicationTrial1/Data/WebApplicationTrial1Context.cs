#nullable disable

using Microsoft.EntityFrameworkCore;
using WebApplicationTrial1.Models;

namespace WebApplicationTrial1.Data
{
    public class WebApplicationTrial1Context : DbContext
    {
        public WebApplicationTrial1Context (DbContextOptions<WebApplicationTrial1Context> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<College> Colleges { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
