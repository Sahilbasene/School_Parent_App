using Microsoft.EntityFrameworkCore;
using School_Parent_App.Models;

namespace School_Parent_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Circular> Circulars { get; set; }




    }
}