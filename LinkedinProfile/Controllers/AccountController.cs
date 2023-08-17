using LinkedinProfile.Helper;
using LinkedinProfile.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinkedinProfile.Controllers
{
    public class AccountController : Controller
    {
        private readonly linkedinContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public AccountController(linkedinContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContext = httpContextAccessor;
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginVM model)
        {
            if (model != null)
            {
                var user = _context.Users.FirstOrDefaultAsync(u => u.Email == model.Mail && u.Password == model.Password).Result;
                if (user == null)
                {
                    TempData["Message"] = "Mail adı veya şifre hatalı!";
                    return RedirectToAction("Login");
                }

                var claims = Util.GetClaims(user);

                Util.SetClaimsIdentity(user, _httpContext);

                return Redirect($"/User/Index?userId={user.UserGuid}");
            }
            else
                return View();


        }

    }
}
