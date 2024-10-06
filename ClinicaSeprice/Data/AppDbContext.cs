using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ClinicaSepriceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
