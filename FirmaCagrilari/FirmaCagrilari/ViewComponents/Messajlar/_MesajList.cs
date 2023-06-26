using FirmaCagrilari.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaCagrilari.ViewComponents.Messajlar
{
    public class _MesajList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            IsTakipDbContext context = new IsTakipDbContext();
            var mail = HttpContext.Session.GetString("Mail");
            var AktifFirma_id = context.TblFirmalars.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var mesajlar = context.TblMesajlars.Where(x => x.Alici == AktifFirma_id).ToList();
    
            ViewBag.msgCount = context.TblMesajlars.Where(x => x.Alici == AktifFirma_id && x.Durum == true).Count();
            return View(mesajlar);
        }
    }
}
