using System.Xml.Serialization;

namespace ShelterHelpService1.Models
{
    [XmlType("Comment")]
    public class Comment
    {
        [XmlAttribute("AuthorName")]
        public string AuthorName { get; set; }

        [XmlAttribute("AuthorAvatar")]
        public string AuthorAvatar { get; set; }

        [XmlAttribute("Category")]
        public string Category { get; set; }

        [XmlAttribute("Rating")]
        public decimal Rating { get; set; }

        [XmlElement("Content")]
        public string Content { get; set; }

        [XmlElement("Files")]
        public string[] Files { get; set; }
    }
}
