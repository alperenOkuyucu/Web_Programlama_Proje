using System.Collections.Generic;

namespace UcakRezervasyonSitesi.Models
{
    public class KoltukOdemeTalimati
    {
        public string KullaniciAdi { get; set; } 
        public int KullaniciId { get; set; }
        public int SecilenKoltukSayisi { get; set; }
        public decimal KoltukBasiFiyat { get; set; }
        public List<int> KoltukNumaraları { get; set; }
    }
}