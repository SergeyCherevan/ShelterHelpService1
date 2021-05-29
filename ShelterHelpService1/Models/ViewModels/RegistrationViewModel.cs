using System.ComponentModel.DataAnnotations;

namespace ShelterHelpService1.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Не указан никнейм")]
        [RegularExpression(@"[A-Za-z0-9_]+", ErrorMessage = "Имя пользователя может содержать только латинские сиволы и цифры")]
        [Display(Name = "Никнейм")]
        [UIHint("UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан Email для регистрации")]
        [RegularExpression(@"[A-Za-z0-9_\.]+@[A-Za-z0-9_]+\.[A-Za-z0-9_\.]+", ErrorMessage = "Некорректный Email")]
        [Display(Name = "Введите Email")]
        [UIHint("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [Display(Name = "Введите пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Display(Name = "Подтвердите введённый пароль")]
        [UIHint("Password")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"[A-Za-z0-9_\.]+@[A-Za-z0-9_]+\.[A-Za-z0-9_\.]+", ErrorMessage = "Некорректный Email")]
        [Display(Name = "Введите публичный Email")]
        [UIHint("PublicEmail")]
        public string PublicEmail { get; set; }
    }
}
