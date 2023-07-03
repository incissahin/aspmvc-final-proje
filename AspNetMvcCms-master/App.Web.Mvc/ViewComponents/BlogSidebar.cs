using App.Business.Abstract;
using App.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.ViewComponents
{
	public class BlogSidebar : ViewComponent
	{
		private readonly ICategoryService _categoryService;
		private readonly IPostService _postService;
		private readonly AppDbContext _appDbContext;

		public BlogSidebar(ICategoryService categoryService, IPostService postService, AppDbContext appDbContext)
		{
			_categoryService = categoryService;
			_postService = postService;
			_appDbContext = appDbContext;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.categories = _appDbContext.Categories.Include(x => x.CategoryPosts);
			ViewBag.posts = _postService.TGetList().Take(3).OrderByDescending(x => x.CreatedAt);
			return View();
		}
	}
}
