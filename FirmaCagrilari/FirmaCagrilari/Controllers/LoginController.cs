using FirmaCagrilari.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FirmaCagrilari.Controllers
{
    public class LoginController : Controller
    {
        IsTakipDbContext context = new IsTakipDbContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(TblFirmalar firma)
        {
            var deger = context.TblFirmalars.FirstOrDefault(x=>x.Mail == firma.Mail && x.Sifre == firma.Sifre);
            if(deger != null)
            {
                // Session["Mail"] = deger.Mail.ToString();
                //                 var claims = new List<Claim>
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,deger.Mail)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                HttpContext.Session.SetString("Mail", deger.Mail.ToString());
                return RedirectToAction("Index","Home");
            }
            return View();
        }


        public IActionResult gitti()
        {
            return View();
        }
    }
}
