using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;

namespace ShelterHelpService1.Models.ViewModels
{
    public class RedactAccountViewModel
    {
        public IFormFile Avatar { get; set; }

        [RegularExpression(@"[A-Za-z0-9_\.]+@[A-Za-z0-9_]+\.[A-Za-z0-9_\.]+", ErrorMessage = "Некорректный Email")]
        [Display(Name = "Email")]
        [UIHint("Email")]
        public string Email { get; set; }

        [RegularExpression(@"[A-Za-z0-9_\.]+@[A-Za-z0-9_]+\.[A-Za-z0-9_\.]+", ErrorMessage = "Некорректный Email")]
        [Display(Name = "Публичный Email")]
        [UIHint("PublicEmail")]
        public string PublicEmail { get; set; }

        [Display(Name = "Новый пароль")]
        [UIHint("NewPassword")]
        [UIHint("NewPassword")]
        public string NewPassword { get; set; }

        [Display(Name = "Подтвердите новый пароль")]
        [UIHint("NewPassword")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmNewPassword { get; set; }

        [Required(ErrorMessage = "Не указан старый пароль")]
        [Display(Name = "Введите старый пароль")]
        [UIHint("Password")]
        public string Password { get; set; }
    }
}
