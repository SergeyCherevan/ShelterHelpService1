using System;

using Microsoft.AspNetCore.Identity;

namespace ShelterHelpService1.Models
{
    public class UserTable : IdentityUser
    {
        public virtual UserCategoryEnum Category { get; set; }
        public virtual string Image { get; set; }
        public virtual string PublicEmail { get; set; }
        public virtual string HtmlPage { get; set; }
        public virtual decimal Rating { get; set; }
        public virtual string XmlComments { get; set; }
        public virtual DateTime? TimeBannedTo { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual string FullName { get; set; }
        public virtual DateTime? LastPaymentDate { get; set; }

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
}
