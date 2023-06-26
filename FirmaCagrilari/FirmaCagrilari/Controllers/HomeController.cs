using FirmaCagrilari.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FirmaCagrilari.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IsTakipDbContext context = new IsTakipDbContext();
        public IActionResult Index()
        {
            //Sisteme Giriş Yapan frmayı bulduk
            var mail = HttpContext.Session.GetString("Mail");
            var id = context.TblFirmalars.Where(x=>x.Mail ==  mail).Select(y=>y.Id).FirstOrDefault();
          
            var aktifCagri = context.TblCagrilars.Where(x => x.Durum == true && x.CagriFirma == id).ToList();
            return View(aktifCagri);
        }


        public IActionResult PasifCagrilar()
        {
            //Sisteme Giriş Yapan frmayı bulduk
            var mail = HttpContext.Session.GetString("Mail");
            var id = context.TblFirmalars.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var pasifCagri = context.TblCagrilars.Where(x => x.Durum == false && x.CagriFirma==id).ToList();
            return View(pasifCagri);
        }

        [HttpGet]
        public IActionResult YeniCagri()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniCagri(TblCagrilar Cagri)
        {
            //Sisteme Giriş Yapan frmayı bulduk
            var mail = HttpContext.Session.GetString("Mail");
            var id = context.TblFirmalars.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();

            Cagri.Durum = true; 
            Cagri.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            Cagri.CagriFirma = id;
            context.Add(Cagri);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult CagriDetay(int id)
        {
            var cagri = context.TblCagriDetays.Where(x=>x.Cagri == id).ToList();
            return View(cagri);
        }

        public IActionResult CagriGetir(int id)
        {
            var cagri = context.TblCagrilars.Find(id);
            return View(cagri);
        }

        public IActionResult CagriDuzenle(TblCagrilar cagri)
        {
            var deger = context.TblCagrilars.Find(cagri.Id);
            deger.Konu = cagri.Konu;
            deger.Aciklama = cagri.Aciklama;
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult ProfilDuzenle()
        {
            //Sisteme Giriş Yapan frmayı bulduk
            var mail = HttpContext.Session.GetString("Mail");
            var AktifFirma_id = context.TblFirmalars.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var deger = context.TblFirmalars.Where(x => x.Id == AktifFirma_id).FirstOrDefault();
            return View(deger);
        }

        [HttpPost]
        public IActionResult ProfilDuzenle(TblFirmalar firma)
        {
            var deger = context.TblFirmalars.Find(firma.Id);
            deger.Name = firma.Name;
            deger.Number = firma.Number;
            deger.Competent = firma.Competent;
            deger.Sifre = firma.Sifre;
            deger.Sector = firma.Sector;
            deger.Province = firma.Province;
            deger.District = firma.District;
            deger.Address = firma.Address;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Anasayfa()
        {
            //Sisteme Giriş Yapan frmayı bulduk
            var mail = HttpContext.Session.GetString("Mail");
            var AktifFirma_id = context.TblFirmalars.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();

            var FirmaImg = context.TblFirmalars.Where(x => x.Id == AktifFirma_id).Select(y => y.Gorsel).FirstOrDefault();
            ViewBag.FirmaImg = FirmaImg;

            var FirmaAdi = context.TblFirmalars.Where(x => x.Id == AktifFirma_id).Select(y => y.Name).FirstOrDefault();
            ViewBag.FirmaAdi = FirmaAdi;

            var toplamCagri = context.TblCagrilars.Where(x=>x.CagriFirma == AktifFirma_id).Count();
            ViewBag.toplamCagri = toplamCagri;

            var aktifCagri = context.TblCagrilars.Where(x => x.CagriFirma == AktifFirma_id && x.Durum == true).Count();
            ViewBag.aktifCagri = aktifCagri;

            var pasifCagri = context.TblCagrilars.Where(x => x.CagriFirma == AktifFirma_id && x.Durum == false).Count();
            ViewBag.pasifCagri = pasifCagri;

            var yetkili = context.TblFirmalars.Where(x => x.Id == AktifFirma_id).Select(y=>y.Competent).FirstOrDefault();
            ViewBag.Yetkili = yetkili;

            var Sector = context.TblFirmalars.Where(x => x.Id == AktifFirma_id).Select(y => y.Sector).FirstOrDefault();
            ViewBag.Sector = Sector;
            return View();
        }
        public async Task<IActionResult> LogOut() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult GelenMesajlar()
        {
            //Sisteme Giriş Yapan frmayı bulduk
            var mail = HttpContext.Session.GetString("Mail");
            var id = context.TblFirmalars.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var mesajlar = context.TblMesajlars.Where(x => x.Durum == true && x.Alici == id).ToList();
            return View(mesajlar);
        }

        public IActionResult GonderilenMesajlar()
        {
            //Sisteme Giriş Yapan frmayı bulduk
            var mail = HttpContext.Session.GetString("Mail");
            var id = context.TblFirmalars.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var mesajlar = context.TblMesajlars.Where(x => x.Durum == true && x.Gonderen == id).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public IActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniMesaj(TblMesajlar mesaj)
        {
            //Sisteme Giriş Yapan frmayı bulduk
            var mail = HttpContext.Session.GetString("Mail");
            var id = context.TblFirmalars.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();

            mesaj.Durum = true;
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderen = id;
            mesaj.Alici = 3;
            context.Add(mesaj);
            context.SaveChanges();
            return RedirectToAction("GonderilenMesajlar", "Home");
        }
    }
}