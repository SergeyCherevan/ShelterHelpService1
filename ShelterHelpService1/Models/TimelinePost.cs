using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShelterHelpService1.Models
{
    public class TimelinePost
    {
        public string Id { get; set; }

        [ForeignKey("Author")]
        public virtual string AuthorId { get; set; }
        public TimelinePostEnum Category { get; set; }
        public string Title { get; set; }
        public DateTime DatePublicating { get; set; }
        public bool IsActual { get; set; }
        public string HtmlPage { get; set; }
        public decimal Rating { get; set; }
        public string XmlComments { get; set; }

        [JsonIgnore]
        public virtual UserEntity Author { get; set; }
    }

    public enum TimelinePostEnum { LostAnimal, FindAnimal, Action, Advertising, ShelterAnimal }
}
