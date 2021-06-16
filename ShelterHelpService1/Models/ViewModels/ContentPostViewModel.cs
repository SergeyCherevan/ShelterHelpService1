using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.AspNetCore.Identity;

namespace ShelterHelpService1.Models.ViewModels
{
    public class ContentPostViewModel
    {
        public ContentPostViewModel() { }
        public ContentPostViewModel(TimelinePost t, UserManager<UserEntity> manager)
        {
            _manager = manager;

            Id = t.Id;
            AuthorName = t.Author.UserName;
            Title = t.Title;
            Category = t.Category;
            DatePublicating = t.DatePublicating;
            IsActual = t.IsActual;
            HtmlPage = t.HtmlPage;
            Rating = t.Rating;

            Task.Run(async () =>
            {
                XmlComments = await AddAvatarsToXmlComments(t.XmlComments);
            }).Wait();
        }

        private readonly UserManager<UserEntity> _manager;

        public string Id { get; set; }
        public string AuthorName { get; set; }
        public TimelinePostEnum Category { get; set; }
        public string Title { get; set; }
        public DateTime DatePublicating { get; set; }
        public bool IsActual { get; set; }
        public string HtmlPage { get; set; }
        public decimal Rating { get; set; }
        public string XmlComments { get; set; }

        public async Task<string> AddAvatarsToXmlComments(string xmlComments)
        {
            if (xmlComments == null || xmlComments == "")
            {
                return xmlComments;
            }

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Comment[]));

                Comment[] comments;

                using (TextReader reader = new StringReader(xmlComments))
                {
                    comments = (Comment[])xmlSerializer.Deserialize(reader);
                }

                foreach (Comment comm in comments)
                {
                    comm.AuthorAvatar = ((UserEntity)await _manager.FindByNameAsync(comm.AuthorName)).Image;
                }

                using (MemoryStream mStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(mStream, comments);

                    xmlComments = Encoding.Default.GetString(mStream.GetBuffer());
                }

                return xmlComments;
            }
            catch (Exception e)
            {
                // throw new ArgumentException("Xml строка не соответствует блоку комментариев: " + e.Message);

                return xmlComments;
            }
        }
    }
}
