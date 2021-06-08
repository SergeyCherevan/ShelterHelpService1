using System.ComponentModel.DataAnnotations;

namespace ShelterHelpService1.Models
{
    public class Correspondence
    {
        public virtual UserEntity User1 { get; set; }
        public virtual string User1Id { get; set; }

        public virtual UserEntity User2 { get; set; }
        public virtual string User2Id { get; set; }

        public virtual string XmlMessages { get; set; }
    }
}
