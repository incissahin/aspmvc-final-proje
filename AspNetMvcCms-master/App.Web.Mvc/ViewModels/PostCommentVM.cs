namespace App.Web.Mvc.ViewModels
{
    public class PostCommentVM
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Comment { get; set; }
    }
}
