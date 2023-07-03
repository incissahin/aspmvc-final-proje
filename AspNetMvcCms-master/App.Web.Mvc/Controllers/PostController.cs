using App.Business.Abstract;
using App.Data.Concrete;
using App.Entities.Concrete;
using App.Web.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPostService _postService;
        private readonly IPostCommentService _postCommentService;

        public PostController(AppDbContext context, IPostCommentService postCommentService)
        {
            _context = context;
            _postCommentService = postCommentService;
        }

        public IActionResult Index(int? categoryId)
        {
			var posts = _context.Posts.Include(x => x.PostComments).Include(x => x.PostImage).Include(x => x.CategoryPosts).ThenInclude(x => x.Category).ToList();

            PostVM postVm = new PostVM();
            postVm.Posts = posts;


            if (categoryId != null)
            {
                postVm.Category = _context.Categories.Where(c => c.Id == categoryId).Include(c => c.CategoryPosts).ThenInclude(cp => cp.Post).ThenInclude(x => x.PostComments).Include(x => x.CategoryPosts).ThenInclude(c => c.Post).ThenInclude(x => x.PostImage).SingleOrDefault();
                postVm.Posts = postVm.Category?.CategoryPosts.Select(cp => cp.Post).ToList();
                return View(postVm);
            }

            return View(postVm);
        }

		public IActionResult Search(string query)
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var post = _context.Posts.Include(x => x.PostComments).ThenInclude(x => x.User).Include(y => y.PostImage).Include(x => x.CategoryPosts).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == id);
            return View(post);
        }



        [HttpPost]
        public IActionResult CreateComment(int userId, int postId, string comment)
        {
            PostComment postComment = new()
            {
                Comment = comment,
                PostId = postId,
                UserId = userId,
            };

            _postCommentService.TAdd(postComment);
            return RedirectToAction("Detail", new {id = postId});
        }

    }
}
