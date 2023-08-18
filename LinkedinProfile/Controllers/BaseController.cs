using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedinProfile.Controllers
{
    public class BaseController : Controller
    {
        public int GetUserId()
        {
            int.TryParse(this.User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
            return userId;
        }

        public string GetUserFullName() => this.User.FindFirstValue(ClaimTypes.Name);
    }
}
