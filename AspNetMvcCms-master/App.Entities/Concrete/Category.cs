using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities.Concrete
{
    public class Category : IAuditEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "İsim alanı maksimum {1} karakter uzunluğunda olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Açıklama alanı maksimum {1} karakter uzunluğunda olabilir.")]
        public string Description { get; set; }


        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
