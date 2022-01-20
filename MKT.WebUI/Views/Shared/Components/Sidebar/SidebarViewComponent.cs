using Microsoft.AspNetCore.Mvc;

namespace MKT.MvcWebUI.Views.Shared.Components.Sidebar
{
    public class SidebarViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Sidebar");
        }
    }
}