using Microsoft.EntityFrameworkCore;
using PetApp.Models;

namespace PetApp.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Pet> Pets { get; set; }
    }
}
