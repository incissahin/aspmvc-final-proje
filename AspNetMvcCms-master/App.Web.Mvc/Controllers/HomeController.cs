using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class HomeController : Controller
    {      
        public IActionResult Index()
        {
            return View();
        }
        
    }
}