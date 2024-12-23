using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.Controllers
{
	public class _LayoutFooterComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
