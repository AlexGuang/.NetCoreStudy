using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("ERROR/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "抱歉，您访问的页面不存在";
                    break;
            }
            return View("NotFound");
        }
    }
}
