using benji_wan_kenobi.Models;
using Microsoft.EntityFrameworkCore;

namespace benji_wan_kenobi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Planet> Planets { get; set; }
    }
}
