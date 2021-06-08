using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ShelterHelpService1.Models;

namespace ShelterHelpService1.Controllers
{
    public class ContentController : Controller
    {
        private readonly ShelterHelpServiceContext _context;

        public ContentController(ShelterHelpServiceContext context, UserManager<UserEntity> manager)
        {
            _context = context;
        }

        public async Task<IActionResult> TimelinePosts()
        {
            IList<TimelinePost> timelinePostTable = await _context.TimelinePostTable
                .Include(x => x.Author)
                .ToListAsync();

            var result = from e in timelinePostTable
                         select (object) new
                         {
                             id = e.Id,
                             authorName = e.Author.UserName,
                             title = e.Title,
                             category = e.Category,
                             datePublicating = e.DatePublicating,
                             isActual = e.IsActual,
                             htmlPage = e.HtmlPage,
                             rating = e.Rating,
                             xmlComments = e.XmlComments,
                         };

            return Json(result);
        }
    }
}
