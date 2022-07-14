using Microsoft.EntityFrameworkCore;
using SnilsList21.Models;

namespace SnilsList21.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
      : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;Database=SnilsDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        public DbSet<Snils> SnilsSet { get; set; }
    }
}
