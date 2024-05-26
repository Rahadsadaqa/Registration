using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Final1.Models;

namespace Project_Final1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project_Final1.Models.Course> Course { get; set; } = default!;
        public DbSet<Project_Final1.Models.Student> Student { get; set; } = default!;
        public DbSet<Project_Final1.Models.Register> Register { get; set; } = default!;
    }
}
