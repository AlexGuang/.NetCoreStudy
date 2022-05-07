using Microsoft.AspNetCore.Mvc;
using System;

namespace deployDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       

        public IActionResult Details()
        {
            return View();
        }
    }
}
