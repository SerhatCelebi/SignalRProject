using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.ViewComponents.DefaultComponents
{
    public class _DefaultMenuComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
