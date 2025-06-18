using Microsoft.EntityFrameworkCore;

namespace LoginRegistrationProject.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}