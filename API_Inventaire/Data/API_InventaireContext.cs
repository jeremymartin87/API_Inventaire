using Microsoft.EntityFrameworkCore;

namespace API_Inventaire.Data
{
    public class API_InventaireContext : DbContext
    {
        public API_InventaireContext (DbContextOptions<API_InventaireContext> options)
            : base(options)
        {
        }

        public DbSet<API_Inventaire.Models.devices> devices { get; set; } = default!;
        public DbSet<API_Inventaire.Models.parcs> parcs { get; set; } = default!;
        public DbSet<API_Inventaire.Models.rooms> rooms { get; set; } = default!;
        public DbSet<API_Inventaire.Models.users> users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}


