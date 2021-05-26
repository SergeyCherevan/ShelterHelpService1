using System;

using Microsoft.AspNetCore.Identity;

namespace ShelterHelpService1.Models
{
    public class User : IdentityUser
    {
        public UserCategoryEnum Category { get; set; }
        public string Image { get; set; }
        public string PublicEmail { get; set; }
        public string HtmlPage { get; set; }
        public decimal Rating { get; set; }
        public string XmlComments { get; set; }
        public DateTime TimeBannedTo { get; set; }
    }

    public enum UserCategoryEnum { SimpleUser, Shelter }
}
