using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities.Concrete
{
    public class User : IAuditEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi girin.")]
        [StringLength(200, ErrorMessage = "Email alanı maksimum {1} karakter uzunluğunda olabilir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az {2} en çok {1} karakterden oluşabilir.")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Şifreler birbiriyle uyuşmuyor.")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "İsim alanı maksimum {1} karakter uzunluğunda olabilir.")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Şehir alanı maksimum {1} karakter uzunluğunda olabilir.")]
        public string City { get; set; }

        [StringLength(20, ErrorMessage = "Telefon alanı maksimum {1} karakter uzunluğunda olabilir.")]
        public string Phone { get; set; }

        public bool IsAdmin { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
