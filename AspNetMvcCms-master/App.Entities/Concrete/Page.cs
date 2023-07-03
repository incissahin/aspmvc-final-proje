using System.ComponentModel.DataAnnotations;

namespace App.Entities.Concrete
{
    public class Page : IAuditEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title alanı boş geçilemez.")]
        [StringLength(200, ErrorMessage = "Title alanı maksimum {1} karakter uzunluğunda olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş geçilemez.")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
