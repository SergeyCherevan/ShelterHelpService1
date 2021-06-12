using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ShelterHelpService1.Models;
using ShelterHelpService1.Models.ViewModels;

namespace ShelterHelpService1.Controllers
{
    public class ContentController : Controller
    {
        private readonly ShelterHelpServiceContext _context;

        private readonly UserManager<UserEntity> _manager;

        public ContentController(ShelterHelpServiceContext context, UserManager<UserEntity> manager)
        {
            _context = context;
            _manager = manager;
        }

        public async Task<IActionResult> TimelinePosts()
        {
            IList<TimelinePost> timelinePostTable = await _context.TimelinePostTable
                .Include(x => x.Author)
                .ToListAsync();

            var result = from e in timelinePostTable
                         select (object) new ContentPostViewModel(e);

            return Json(result);
        }

        public async Task<IActionResult> User(string param1)
        {
            return View(new ContentUserViewModel(await _manager.FindByNameAsync(param1)));
        }

        public async Task<IActionResult> Post(string param1)
        {
            return View(new ContentPostViewModel(
                await _context.TimelinePostTable
                    .Include(e => e.Author)
                    .FirstAsync(e => e.Id == param1)
            ));
        }
    }
}
