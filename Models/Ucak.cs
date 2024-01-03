 namespace UcakRezervasyonSitesi.Models
 {   
    public class Ucak
    {
        public int Id { get; set; }
        public string Model { get; set; } // Uçağın modeli
        public decimal KoltukFiyati { get; set; }
        public string KalkisNoktasi { get; set; }
        public string VarisNoktasi { get; set; }
        public int KoltukSatir { get; set; } // Koltuk düzeni
        public int KoltukSutun { get; set; } // Koltuk düzeni
    }
 }