using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_Net7.Models;
using System.Data.Common;

namespace SuperHeroAPI_Net7.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-OB4R700\\SQLEXPRESS;Database= SuperHeroDatabase7;Trusted_Connection=true;TrustServerCertificate=True");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
