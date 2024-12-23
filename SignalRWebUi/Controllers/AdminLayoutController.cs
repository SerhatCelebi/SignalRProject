using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
