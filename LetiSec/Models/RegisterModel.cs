
using System.ComponentModel.DataAnnotations;

namespace LetiSec.Models
{
    public class RegisterModel
    {
      
        [Required(ErrorMessage = "Введите Имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите Почту")]
        [Display(Name = "Почта")]
        [UIHint("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Display(Name = "Номер телефона")]
        [UIHint("Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(20, MinimumLength =6)]
        [Compare("ConfirmPassword")]
        [Display(Name = "Пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Подтверждение пароля")]
        [UIHint("Password")]
        public string ConfirmPassword { get; set; }

    }
}
