using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
