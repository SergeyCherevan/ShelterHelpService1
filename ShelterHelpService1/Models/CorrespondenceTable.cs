using System.ComponentModel.DataAnnotations;

namespace ShelterHelpService1.Models
{
    public class CorrespondenceTable
    {
        public UserTable UserId1Fk { get; set; }

        public UserTable UserId2Fk { get; set; }

        public virtual string XmlMessages { get; set; }
    }
}
