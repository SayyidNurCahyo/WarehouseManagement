using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WarehouseManagement.Entities;

namespace WarehouseManagement.Repositories
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Gudang> Gudang { get; set; }
        public DbSet<Barang> Barang { get; set; }
        protected AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
