using Microsoft.EntityFrameworkCore;

namespace UcakRezervasyonSitesi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Ucak> Ucaklar { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici
                {
                    KullaniciId = 5,
                    KullaniciAdi = "g201210056@sakarya.edu.tr",
                    Sifre = "sau",
                    AdminOncelik = true,
                }
            );
        }
    }
}
