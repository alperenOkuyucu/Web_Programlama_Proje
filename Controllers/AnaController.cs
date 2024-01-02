using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcakRezervasyonSitesi.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace UcakRezervasyonSitesi.Controllers
{
    public class AnaController : Controller
    {
        private readonly AppDbContext _context;

        public AnaController(AppDbContext context) {
            _context = context;
        }

        async public Task<IActionResult> Index()
        {
            var kalkisNoktalari = await _context.Ucaklar.Select(u => u.KalkisNoktasi).Distinct().ToListAsync();
            var varisNoktalari = await _context.Ucaklar.Select(u => u.VarisNoktasi).Distinct().ToListAsync();

            // Listeleri birleştir ve tekrar edenleri sil
            var tumNoktalar = kalkisNoktalari.Concat(varisNoktalari).Distinct().ToList();

            // Listeyi görünüme geçir
            ViewBag.NoktaSecenekleri = tumNoktalar;

            return View();
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(Kullanici kullanici)
        {
            var user = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.KullaniciAdi == kullanici.KullaniciAdi && k.Sifre == kullanici.Sifre);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", kullanici.KullaniciAdi);
                SetKullaniciInSession(kullanici);
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }


        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(Kullanici yeniKullanici)
        {
            yeniKullanici.AdminOncelik = false;

            _context.Kullanicilar.Add(yeniKullanici);
            await _context.SaveChangesAsync();
            return RedirectToAction("Giris");
        }


        public IActionResult CikisYap()
        {
            HttpContext.Session.Clear(); // Clear session
             HttpContext.Session.SetString("Kullanici", "");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UcusAra(UcusArama aramaKriterleri)
        {
            var filtrelenmisUcaklar = _context.Ucaklar
            .Where(u => u.KalkisNoktasi == aramaKriterleri.KalkisHavalimani &&
                        u.VarisNoktasi == aramaKriterleri.VarisHavalimani)
            .ToList();

            return View("RezervasyonYap", filtrelenmisUcaklar);
        }

        [HttpPost]
        public async Task<IActionResult> KoltukSecimi(int ucakId)
        {
            var secilenUcak = await _context.Ucaklar.FirstOrDefaultAsync(u => u.Id == ucakId);

            if (secilenUcak != null)
            {
                var viewModel = new KoltukSecimiData
                {
                    Ucak = secilenUcak,
                    Kullanici = GetKullaniciFromSession()
                };

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Odeme(string KullaniciAdi, int KullaniciId, int SecilenKoltukSayisi, decimal KoltukBasiFiyat)
        {
            var talimat = new KoltukOdemeTalimati
            {
                KullaniciAdi = KullaniciAdi,
                KullaniciId = KullaniciId,
                SecilenKoltukSayisi = SecilenKoltukSayisi,
                KoltukBasiFiyat = KoltukBasiFiyat
            };

            return View(talimat);
        }


        [HttpGet]
        public IActionResult AdminGiris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminGiris(Kullanici kullanici)
        {
            var user = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.KullaniciAdi == kullanici.KullaniciAdi && k.Sifre == kullanici.Sifre);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", kullanici.KullaniciAdi);
                if (user.AdminOncelik)
                {
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult AdminPanel()
        {
            var isAdmin = HttpContext.Session.GetString("Username") != null && _context.Kullanicilar.Any(k => k.KullaniciAdi == HttpContext.Session.GetString("Username") && k.AdminOncelik);

            if (isAdmin)
            {
                var planes = _context.Ucaklar.ToList();
                var ucakViewModel = new UcakViewModel();
                ViewBag.UcakFormModel = ucakViewModel;
                return View(planes);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UcakEkle(string Model, decimal KoltukFiyati, string KalkisNoktasi, string VarisNoktasi)
        {
            var ucak = new Ucak
            {
                Model = Model,
                KoltukFiyati = KoltukFiyati,
                KalkisNoktasi = KalkisNoktasi,
                VarisNoktasi = VarisNoktasi
            };
            
            _context.Ucaklar.Add(ucak);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public async Task<IActionResult> UcakSil(int id)
        {
            var ucak = await _context.Ucaklar.FindAsync(id);
            if (ucak != null)
            {
                _context.Ucaklar.Remove(ucak);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public async Task<IActionResult> UcakGuncelle(int Id, string Model, decimal KoltukFiyati, string KalkisNoktasi, string VarisNoktasi)
        {
            var ucak = await _context.Ucaklar.FindAsync(Id);
            if (ucak != null)
            {
                ucak.Model = Model;
                ucak.KoltukFiyati = KoltukFiyati;
                ucak.KalkisNoktasi = KalkisNoktasi;
                ucak.VarisNoktasi = VarisNoktasi;

                _context.Update(ucak);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("AdminPanel"); // Replace with your actual admin panel action
        }

        public void SetKullaniciInSession(Kullanici kullanici)
        {
            var serializedKullanici = JsonSerializer.Serialize(kullanici);
            HttpContext.Session.SetString("Kullanici", serializedKullanici);
        }

        public Kullanici GetKullaniciFromSession()
        {
            var serializedKullanici = HttpContext.Session.GetString("Kullanici");
            return serializedKullanici == null ? null : JsonSerializer.Deserialize<Kullanici>(serializedKullanici);
        }

    }
}
