using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorCode401()
        {
            return View();
        }

        public IActionResult ErrorCode404()
        {
            return View();
        }
    }
}
