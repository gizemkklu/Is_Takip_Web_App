using Microsoft.AspNetCore.Mvc;

namespace FirmaCagrilari.ViewComponents.accordions
{
    public class _Accordions:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
