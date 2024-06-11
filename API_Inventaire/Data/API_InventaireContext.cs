using Microsoft.EntityFrameworkCore;

namespace API_Inventaire.Data
{
    public class API_InventaireContext : DbContext
    {
        public API_InventaireContext (DbContextOptions<API_InventaireContext> options)
            : base(options)
        {
        }

        public DbSet<API_Inventaire.Models.Devices> Devices { get; set; } = default!;
        public DbSet<API_Inventaire.Models.Parcs> Parcs { get; set; } = default!;
        public DbSet<API_Inventaire.Models.Rooms> Rooms { get; set; } = default!;
        public DbSet<API_Inventaire.Models.Users> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}


