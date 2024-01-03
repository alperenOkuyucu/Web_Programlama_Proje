namespace UcakRezervasyonSitesi.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public bool AdminOncelik { get; set; }
    }
}