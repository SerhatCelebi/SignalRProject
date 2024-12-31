using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
