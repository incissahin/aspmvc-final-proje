using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities.Concrete
{
    public class Post : IAuditEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [StringLength(200, ErrorMessage = "Başlık alanı maksimum {1} karakter uzunluğunda olabilir.")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş geçilemez.")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }


        public virtual User User { get; set; }
        public virtual PostImage PostImage { get; set; }
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
