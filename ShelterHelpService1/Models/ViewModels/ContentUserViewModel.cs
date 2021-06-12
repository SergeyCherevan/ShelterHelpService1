using System;

namespace ShelterHelpService1.Models.ViewModels
{
    public class ContentUserViewModel
    {
        public ContentUserViewModel() { }
        public ContentUserViewModel(UserEntity u)
        {
            UserName = u.UserName;
            Category = u.Category;
            FirstName = u.FirstName;
            LastName = u.LastName;
            FullName = u.FullName;
            Image = u.Image;
            PublicEmail = u.PublicEmail;
            HtmlPage = u.HtmlPage;
            Rating = u.Rating;
            XmlComments = u.XmlComments;
            TimeBannedTo = u.TimeBannedTo;
        }

        public string UserName { get; set; }
        public UserCategoryEnum Category { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Image { get; set; }
        public string PublicEmail { get; set; }
        public string HtmlPage { get; set; }
        public decimal Rating { get; set; }
        public string XmlComments { get; set; }
        public DateTime? TimeBannedTo { get; set; }
    }
}
