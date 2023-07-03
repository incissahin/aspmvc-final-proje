using App.Entities.Concrete;

namespace App.Web.Mvc.ViewModels
{
	public class PostVM
	{

		public Category Category { get; set; }
		public List<Post> Posts { get; set; }

		//      public string Content { get; set; }
		//public DateTime CreatedAt { get; set; }
		//public int Id { get; set; }
		//      public List<PostComment> PostComments { get; set; }
		//      public PostImage PostImage { get; set; }
		//      public string Title { get; set; }
		//      public int UserId { get; set; }
	}
}
