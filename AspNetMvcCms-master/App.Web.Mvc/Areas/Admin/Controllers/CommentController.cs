using App.Business.Concrete;
using App.Data.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
    [Authorize(Policy = "RequireAdminRole")]
    public class CommentController : Controller
	{
		private readonly PostCommentManager _postCommentManager;
		private readonly PostManager _postManager;
		private readonly UserManager _userManager;

		public CommentController()
		{
			_postCommentManager = new PostCommentManager(new EfPostCommentDal());
			_postManager = new PostManager(new EfPostDal());
			_userManager = new UserManager(new EfUserDal());
		}

		public IActionResult Index()
		{
			var comments = _postCommentManager.TGetList();
			comments.ForEach(comment =>
			{
				comment.User = _userManager.TGetByID(comment.UserId);
				comment.Post = _postManager.TGetByID(comment.PostId);
			});
			return View(comments);
		}

		public IActionResult DetailsComment(int id)
		{
			var values = _postCommentManager.TGetByID(id);
			_postCommentManager.TGetList().Add(values);
			return View(values);
		}

		public IActionResult DeleteComment(int id)
		{
			var values = _postCommentManager.TGetByID(id);
			_postCommentManager.TDelete(values);
			return RedirectToAction("Index");
		}
		

		public async Task<IActionResult> CommentActive(int id)
		{
			await _postCommentManager.CommentActive(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UnComment(int id)
		{
			await _postCommentManager.Uncomment(id);
			return RedirectToAction("Index");
		}


	}
}
