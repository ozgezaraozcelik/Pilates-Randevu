using Microsoft.EntityFrameworkCore;
using pilates_randevu_2.Models;

namespace pilates_randevu_2.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-G9S7ULIT\\SQLEXPRESS;initial Catalog=PilatesRandevuDb;integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<RandevuKayıt> RandevuKayitlari { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }

    }
}
