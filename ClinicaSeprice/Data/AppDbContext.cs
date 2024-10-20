using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }
    }
}
