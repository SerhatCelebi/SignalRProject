using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.Controllers
{
	public class SinalRDefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Index2()
        {
            return View();
        }
    }
}
