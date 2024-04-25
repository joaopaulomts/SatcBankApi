using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
        public DbSet<Transferencia> Transferencia { get; set; }
    }
}
