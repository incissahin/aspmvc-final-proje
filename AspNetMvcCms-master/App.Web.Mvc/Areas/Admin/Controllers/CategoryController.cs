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
    public class CategoryController : Controller
	{
		private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
		public IActionResult Index()
		{
			var values = _categoryManager.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			category.CreatedAt = DateTime.Now;
			_categoryManager.TAdd(category);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EditCategory(int id)
		{
			var values = _categoryManager.TGetByID(id);
			if (values == null)
			{
				return RedirectToAction("Index");
			}
			return View(values);
		}
		[HttpPost]

		public IActionResult EditCategory(Category category)
		{

			_categoryManager.TUpdate(category);
			category.UpdatedAt = DateTime.Now;
			return RedirectToAction("Index");
		}

		public IActionResult DeleteCategory(int id)
		{
			var values = _categoryManager.TGetByID(id);
			_categoryManager.TDelete(values);
			return RedirectToAction("Index");
		}
	}
}
