using FirmaCagrilari.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirmaCagrilari.ViewComponents.Cagrilar
{
    public class _GelenCagriList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            IsTakipDbContext context = new IsTakipDbContext();
            var mail = HttpContext.Session.GetString("Mail");
            var id = context.TblFirmalars.Where(x=>x.Mail == mail).Select(y=>y.Id).FirstOrDefault();
            var cagrilar = context.TblCagrilars.Where(x => x.CagriFirma == id).ToList();
            ViewBag.cgriCount = context.TblCagrilars.Where(x => x.CagriFirma == id && x.Durum == true).Count();
            return View(cagrilar);
        }
    }
}
