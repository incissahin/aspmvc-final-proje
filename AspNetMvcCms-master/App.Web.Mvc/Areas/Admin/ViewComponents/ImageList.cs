using App.Business.Concrete;
using App.Data.EntityFramework;
using App.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Web.Mvc.Areas.Admin.ViewComponents
{
    public class ImageList : ViewComponent
    {
        private readonly PostManager _postManager = new PostManager(new EfPostDal());
        private readonly PostImageManager _postImageManager = new PostImageManager(new EfPostImageDal());

        public IViewComponentResult Invoke()
        {
            var postImages = _postImageManager.TGetList();
            var posts = _postManager.TGetList();

            var model = CombinePostAndPostImages(posts, postImages);

            return View(model);
        }

        private List<PostImage> CombinePostAndPostImages(List<Post> posts, List<PostImage> postImages)
        {
            var model = new List<PostImage>();

            foreach (var postImage in postImages)
            {
                var post = posts.FirstOrDefault(p => p.Id == postImage.PostId);

                if (post != null)
                {
                    postImage.Post = post;
                    model.Add(postImage);
                }
            }

            return model;
        }

    }
}
