using App.Business.Concrete;
using App.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.ViewComponents
{
	public class UserList : ViewComponent
	{
		private readonly UserManager _userManager = new UserManager(new EfUserDal());

		public IViewComponentResult Invoke()
		{

			var posts = _userManager.TGetList();


			return View(posts);
		}
	}
}
