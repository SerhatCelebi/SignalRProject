using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
