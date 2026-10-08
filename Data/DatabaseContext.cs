using EnvioEmail.Models;
using Microsoft.EntityFrameworkCore;

namespace EnvioEmail.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
    
}
