using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LetiSec.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите Почту")]
        [Display(Name = "Почта")]
        [UIHint("Email")]
        public string Email { get; set; }
        

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        [UIHint("Password")]
        public string Password { get; set; }
    }
}
