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
    public class UserController : Controller
    {
        private readonly UserManager _userManager = new UserManager(new EfUserDal());
        private readonly PostCommentManager _postCommentManager = new PostCommentManager(new EfPostCommentDal());
        public IActionResult Index()
        {
            var values = _userManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditUser(int id) 
        {
			var values = _userManager.TGetByID(id);
			if (values == null)
			{
				return RedirectToAction("Index");
			}
			return View(values);
		}
        [HttpPost]
		public IActionResult EditUser(User user)
        {

			_userManager.TUpdate(user);
			user.UpdatedAt = DateTime.Now;
			return RedirectToAction("Index");
		}

		public IActionResult DetailsUser (int id)
        {
            var values = _userManager.TGetByID(id);
            _userManager.TGetList().Add(values);
            return View(values);
        }
        public IActionResult DeleteUser(int id)
        {
            var postComment = _postCommentManager.TGetListbyFilter(a => a.UserId == id);
            foreach(var item in postComment)
            {
                _postCommentManager.TDelete(item);
            }


            var values = _userManager.TGetByID(id);
            _userManager.TDelete(values);
			return RedirectToAction("Index");
		}


		public async Task<IActionResult> RoleUser(int id)
        {
            await _userManager.RoleUser(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UnRoleUser (int id)
        {
            await _userManager.UnRoleUser(id);
            return RedirectToAction("Index");
        }
    }
}
