using System;

namespace ShelterHelpService1.Models
{
    public class TimelinePostTable
    {
        public UserTable AuthorIdFk { get; set; }
        public string Title { get; set; }
        public DateTime DatePublicating { get; set; }
        public bool IsActual { get; set; }
        public string HtmlPage { get; set; }
        public virtual decimal Rating { get; set; }
        public virtual string XmlComments { get; set; }
    }

    public enum TimelinePostEnum { LostAnimal, FindAnimal, Action, Advertising, ShelterAnimal }
}
