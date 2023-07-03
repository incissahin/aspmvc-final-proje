using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.ViewModels
{
    public class UserLoginVM
    {
        [Required(ErrorMessage ="Email alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
