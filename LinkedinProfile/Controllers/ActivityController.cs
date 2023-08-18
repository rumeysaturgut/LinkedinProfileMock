using LinkedinProfile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkedinProfile.Controllers
{
    public class ActivityController : Controller
    {
        private readonly linkedinContext _context;

        public ActivityController(linkedinContext context)
        {
            _context = context;
        }

        public IActionResult GetUserActivities(string userId)
        {
            var user = _context.Users.Where(x => x.UserGuid == userId).FirstOrDefault();

            ViewBag.UserId = user.UserId;
            return View();
        }

        public IActionResult GetActivityOfType(string? type,int userId)
        {
            if (userId != null)
            {
                var model = _context.Users.Where(u => u.UserId == userId)
                    .Include(i => i.Comments).ThenInclude(x => x.Post)
                    .Include(i => i.Likes).ThenInclude(x => x.Post)
                    .Include(i => i.Shares).ThenInclude(x => x.Post).ThenInclude(x=>x.User)
                    .Include(i => i.Posts).ThenInclude(x => x.Likes)
                    .Include(i => i.Posts).ThenInclude(x => x.Comments).ThenInclude(x=>x.User)
                    .Include(i => i.Posts).ThenInclude(x => x.Shares).FirstOrDefault();

                ViewBag.Type = type ?? "Posts";

                return View("_DetailsOfActivity", model);

            }

            return View();

        }

    }
}
