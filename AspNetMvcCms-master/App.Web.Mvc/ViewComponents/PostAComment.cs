using App.Business.Abstract;
using App.Entities.Concrete;
using App.Web.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
	public class PostAComment : ViewComponent
	{


		public IViewComponentResult Invoke(int postId, int userId)
		{
		
			PostCommentVM vm = new PostCommentVM()
			{
				PostId = postId,
				UserId = userId
			};
			return View(vm);
		}



	}
}
