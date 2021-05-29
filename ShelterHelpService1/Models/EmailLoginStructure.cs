using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterHelpService1.Models
{
    public class EmailLoginStructure : LoginStructure
    {
        public override LoginCategoryEnum Category { get => LoginCategoryEnum.EmailLogin; set { } }
        public string RegistrationEmail { get; set; }
        public string PasswordHash { get; set; }
    }
}
