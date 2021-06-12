using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;

namespace ShelterHelpService1.Models.ViewModels
{
    public class RedactAccountViewModel
    {
        [Display(Name = "Аватарка")]
        [UIHint("Avatar")]
        public IFormFile Avatar { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"[A-Za-z0-9_\.]+@[A-Za-z0-9_]+\.[A-Za-z0-9_\.]+", ErrorMessage = "Некорректный Email")]
        [Display(Name = "Email")]
        [UIHint("Email")]
        public string Email { get; set; }

        [Display(Name = "Новый пароль")]
        [UIHint("NewPassword")]
        public string NewPassword { get; set; }

        [Display(Name = "Подтвердите новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [UIHint("NewPassword")]
        public string ConfirmNewPassword { get; set; }

        [Required(ErrorMessage = "Не указан старый пароль")]
        [Display(Name = "Введите старый пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Display(Name = "Имя")]
        [UIHint("FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [UIHint("LastName")]
        public string LastName { get; set; }

        [Display(Name = "Полное название организации")]
        [UIHint("FullName")]
        public string FullName { get; set; }

        [RegularExpression(@"[A-Za-z0-9_\.]+@[A-Za-z0-9_]+\.[A-Za-z0-9_\.]+", ErrorMessage = "Некорректный Email")]
        [Display(Name = "Публичный Email")]
        [UIHint("PublicEmail")]
        public string PublicEmail { get; set; }

        [Required(ErrorMessage = "Невозможно создать путой пост")]
        [Display(Name = "Содержание поста")]
        [UIHint("HtmlPage")]
        public string HtmlPage { get; set; }
    }
}
