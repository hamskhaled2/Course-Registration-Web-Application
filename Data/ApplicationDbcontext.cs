using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_information_system_2.Models;

namespace Student_information_system_2.Data
{
    public class ApplicationDbcontext : IdentityDbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options): base(options)
        {
        
        }

        public DbSet<Student> Student { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Course> Course { get; set; }

    }
}
