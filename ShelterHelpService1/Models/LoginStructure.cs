using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterHelpService1.Models
{
    public abstract class LoginStructure
    {
        public string UserName { get; set; }
        public virtual LoginCategoryEnum Category { get; set; }
    }

    public enum LoginCategoryEnum { EmailLogin, GoogleApiLogin, FacebookApiLogin }
}
