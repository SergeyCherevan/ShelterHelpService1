using System;

namespace ShelterHelpService1.Models.ViewModels
{
    public class ContentPostViewModel
    {
        public ContentPostViewModel() { }
        public ContentPostViewModel(TimelinePost t)
        {
            Id = t.Id;
            AuthorName = t.Author.UserName;
            Title = t.Title;
            Category = t.Category;
            DatePublicating = t.DatePublicating;
            IsActual = t.IsActual;
            HtmlPage = t.HtmlPage;
            Rating = t.Rating;
            XmlComments = t.XmlComments;
        }

        public string Id { get; set; }
        public string AuthorName { get; set; }
        public TimelinePostEnum Category { get; set; }
        public string Title { get; set; }
        public DateTime DatePublicating { get; set; }
        public bool IsActual { get; set; }
        public string HtmlPage { get; set; }
        public decimal Rating { get; set; }
        public string XmlComments { get; set; }
    }
}
