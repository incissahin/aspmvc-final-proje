using App.Business.Concrete;
using App.Data.Concrete;
using App.Data.EntityFramework;
using App.Entities.Concrete;
using App.Web.Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace App.Web.Mvc.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Policy = "RequireAdminRole")]
    public class BlogController : Controller
    {
        private readonly PostManager _postManager = new PostManager(new EfPostDal());

        private readonly PostImageManager _postImageManager = new PostImageManager(new EfPostImageDal());

        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        private readonly CategoryPostManager _categoryPostManager = new CategoryPostManager(new EfCategoryPostDal());

        private readonly UserManager _userManager = new UserManager(new EfUserDal());

        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _postManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPost(AddPostViewModel model)
        {
            TempData["User"] = _userManager.TGetListbyFilter(a=>a.Id == model.UserId).Any();    
            TempData["Category"] = _categoryManager.TGetList();
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View();
        }

        public IActionResult DetailsBlog(int id)
        {
            var values = _postManager.TGetByID(id);
            _postManager.TGetList().Add(values);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostViewModel model, IFormFile ImagePath)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(ImagePath.FileName);
            var Imagename = Guid.NewGuid() + extension;
            var SaveLocation = resource + "/wwwroot/postimages/" + Imagename;
            var Stream = new FileStream(SaveLocation, FileMode.Create);
            await ImagePath.CopyToAsync(Stream);


            Post post = new Post()
            {
                UserId = model.UserId,
                Title = model.Title,
                Content = model.Content,
                CreatedAt = DateTime.Now

            };
            _postManager.TAdd(post);

            CategoryPost categoryPost = new CategoryPost()
            {
                CategoryId = model.CategoryId,
                PostId = post.Id,
            };
            _categoryPostManager.TAdd(categoryPost);

            PostImage image = new PostImage()
            {
                PostId = post.Id,
                ImagePath = $"/{Imagename}"
            };
            _postImageManager.TAdd(image);

            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }


        public IActionResult EditBlog(int id)
        {
            //var post = _postManager.TGetByID(id);
            var post = _context.Posts.Include(x => x.PostImage).FirstOrDefault(x => x.Id == id);
            TempData["User"] = _userManager.TGetListbyFilter(a => a.Id == post.UserId).Any();
            TempData["Category"] = _categoryManager.TGetList();
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            AddPostViewModel model = new AddPostViewModel()
            {
                PostId = post.Id,
                UserId = post.UserId,
                Title = post.Title,
                Content = post.Content,
                ImageId = post.PostImage.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlog(AddPostViewModel model, IFormFile ImagePath)
        {
            
            Post post = new Post()
            {
                Id = model.PostId,
                UserId = model.UserId,
                Title = model.Title,
                Content = model.Content,
                UpdatedAt = DateTime.Now
            };
            _postManager.TUpdate(post);

            CategoryPost categoryPost = new CategoryPost()
            {
                Id = model.CategoryPostId,
                CategoryId = model.CategoryId,
                PostId = post.Id,
            };
            _categoryPostManager.TUpdate(categoryPost);

            if(ImagePath != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(ImagePath.FileName);
                var Imagename = Guid.NewGuid() + extension;
                var SaveLocation = resource + "/wwwroot/postimages/" + Imagename;
                var Stream = new FileStream(SaveLocation, FileMode.Create);
                await ImagePath.CopyToAsync(Stream);

                PostImage image = new PostImage()
                {
                    Id = model.ImageId,
                    PostId = post.Id,
                    ImagePath = $"/{Imagename}"
                };
                _postImageManager.TUpdate(image);
            }
            

            return RedirectToAction("Index", "Blog", new {area = "Admin"});
        }

        public IActionResult DeleteBlog(int id)
        {
            var post = _postManager.TGetByID(id);
            _postManager.TDelete(post);
            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }
    }
}
