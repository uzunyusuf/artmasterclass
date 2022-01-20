using Microsoft.AspNetCore.Mvc;

namespace MKT.MvcWebUI.Views.Shared.Components.Navbar
{
    public class NavbarViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Navbar");
        }
    }
}