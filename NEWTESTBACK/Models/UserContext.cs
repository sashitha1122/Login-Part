using Microsoft.EntityFrameworkCore;

namespace NEWTESTBACK.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }

        public DbSet<Venders> Venders { get; set; }
    }
}
