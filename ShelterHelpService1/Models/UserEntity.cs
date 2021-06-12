using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ShelterHelpService1.Models
{
    public class UserEntity : IdentityUser
    {
        public UserCategoryEnum Category { get; set; }
        public string Image { get; set; }
        public string PublicEmail { get; set; }
        public string HtmlPage { get; set; }
        public decimal Rating { get; set; }
        public string XmlComments { get; set; }
        public DateTime? TimeBannedTo { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }
        public DateTime? LastPaymentDate { get; set; }

        [JsonIgnore]
        [InverseProperty("Author")]
        public virtual ICollection<TimelinePost> TimelinePosts { get; set; } = new List<TimelinePost>();

        public User GetUser()
        {
            if (Category == UserCategoryEnum.SimpleUser)
            {
                return new SimpleUser
                {
                    UserName = this.UserName,
                    Category = this.Category,
                    LoginStructure = new EmailLoginStructure
                    {
                        Category = LoginCategoryEnum.EmailLogin,
                        UserName = this.UserName,
                        RegistrationEmail = this.Email
                    },
                    Image = this.Image,
                    PublicEmail = this.PublicEmail,
                    HtmlPage = this.HtmlPage,
                    Rating = this.Rating,
                    XmlComments = this.XmlComments,
                    TimeBannedTo = this.TimeBannedTo,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                };
            }
            else if (Category == UserCategoryEnum.Shelter)
            {
                return new Shelter
                {
                    UserName = this.UserName,
                    Category = this.Category,
                    LoginStructure = new EmailLoginStructure
                    {
                        Category = LoginCategoryEnum.EmailLogin,
                        UserName = this.UserName,
                        RegistrationEmail = this.Email
                    },
                    Image = this.Image,
                    PublicEmail = this.PublicEmail,
                    HtmlPage = this.HtmlPage,
                    Rating = this.Rating,
                    XmlComments = this.XmlComments,
                    TimeBannedTo = this.TimeBannedTo,
                    FullName = this.FirstName,
                    LastPaymentDate = (DateTime)this.LastPaymentDate,
                };
            }

            return null;
        }
    }

    public enum UserCategoryEnum { SimpleUser, Shelter }

    public class ListOfUserCategories
    {
        public List<string> list = new List<string> { "Обычный пользователь", "Приют" };
    }
}
