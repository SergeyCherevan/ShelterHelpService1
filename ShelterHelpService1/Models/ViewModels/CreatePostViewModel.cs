using System.ComponentModel.DataAnnotations;

namespace ShelterHelpService1.Models.ViewModels
{
    public class CreatePostViewModel
    {
        [Required(ErrorMessage = "Не указан заголовок")]
        [Display(Name = "Заголовок поста")]
        [UIHint("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Не указана категория поста")]
        [Display(Name = "Категория поста")]
        [UIHint("Category")]
        public TimelinePostEnum Category { get; set; }

        [Required(ErrorMessage = "Невозможно создать путой пост")]
        [Display(Name = "Содержание поста")]
        [UIHint("HtmlPage")]
        public string HtmlPage { get; set; }
    }
}
