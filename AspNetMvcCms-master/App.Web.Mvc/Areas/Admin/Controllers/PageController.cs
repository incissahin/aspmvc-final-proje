using App.Business.Concrete;
using App.Data.EntityFramework;
using App.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Policy = "RequireAdminRole")]
    public class PageController : Controller
    {
        PageManager _pageManager = new PageManager(new EfPageDal());
        public IActionResult Index()
        {
            var values = _pageManager.TGetList();
            return View(values);
        }

		[HttpGet]
		public IActionResult AddPage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddPage(Page page)
		{
			_pageManager.TAdd(page);
			page.CreatedAt = DateTime.Now;
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EditPage(int id)
		{
			var values = _pageManager.TGetByID(id);
			if (values == null)
			{
				return RedirectToAction("Index");
			}
			return View(values);
		}

		[HttpPost]

		public IActionResult EditPage(Page page)
		{

			_pageManager.TUpdate(page);
			page.UpdatedAt = DateTime.Now;
			return RedirectToAction("Index");
		}


		public IActionResult DeletePage(int id)
		{
			var values = _pageManager.TGetByID(id);
			_pageManager.TDelete(values);
			return RedirectToAction("Index");
		}
	}
}
