namespace App.Web.Mvc.Areas.Admin.Models
{
	public class AddPostViewModel
	{
		public int UserId { get; set; }
		public int ImageId { get; set; }
		public int PostId { get; set; }
		public int CategoryId { get; set; }
		public int CategoryPostId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
        public IFormFile? ImagePath { get; set; }

    }
}
