using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterHelpService1.Models
{
    public abstract class User
    {
        public UserCategoryEnum Category { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public LoginStructure LoginStructure { get; set; }
        public string PublicEmail { get; set; }
        public string HtmlPage { get; set; }
        public decimal Rating { get; set; }
        public string XmlComments { get; set; }
        public DateTime? TimeBannedTo { get; set; }
    }
}
