﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
