using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	public class DashboardController : Controller
	{

        [Area("Admin")]
        [Route("Admin/[controller]/[action]")]
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Index()
		{
			return View();
		}
	}
}
