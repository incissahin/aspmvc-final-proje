using App.Business.Concrete;
using App.Data.EntityFramework;
using App.Web.Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.ViewComponents
{
	public class MixList : ViewComponent
	{
		private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

		public IViewComponentResult Invoke()
		{

			var posts = _categoryManager.TGetList();

			
			return View(posts);
		}


	}
}
