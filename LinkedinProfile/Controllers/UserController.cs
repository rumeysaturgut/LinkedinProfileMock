using LinkedinProfile.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkedinProfile.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly linkedinContext _context;

        public UserController(linkedinContext context)
        {
            _context = context;
        }

        // GET: Users
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Users != null ? 
        //                  View(await _context.Users.ToListAsync()) :
        //                  Problem("Entity set 'LinkedinContext.Users'  is null.");


        public IActionResult Index(string userId)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.UserGuid == userId).Result;
            ViewBag.UserGuid = user.UserGuid;
            ViewBag.UserFullname = GetUserFullName();

            return View();
        }


        public IActionResult GetUserInfos(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = _context.Users.Where(u => u.UserGuid == id).Include(p => p.Profiles).FirstOrDefault();

                if (user == null)
                {
                    TempData["Message"] = "Kullanıcı bulunamadı";
                    return View();
                }

                return PartialView("_GetUserInfos", user);
            }
            else
                return View();
        }

        public IActionResult CommunicationInfos(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = _context.Users.Where(u => u.UserGuid == id).Include(p => p.Profiles).FirstOrDefault();

                if (user == null)
                {
                    TempData["Message"] = "Kullanıcı bulunamadı";
                    return View();
                }

                return View(user);
            }
            else
                return View();
        }


    }
}
