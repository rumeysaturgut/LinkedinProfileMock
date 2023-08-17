using LinkedinProfile.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinProfile.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        private readonly linkedinContext _context;

        public EducationController(linkedinContext context)
        {
            _context = context;
        }

        public IActionResult GetUserEducations(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var educations = _context.Educations.Where(e => e.User.UserGuid == id).OrderByDescending(o => o.StartDate.Year).ToList();
                if (educations == null)
                {
                    //TempData["Message"] = "Kullanıcıya ait deneyim bulunamadı";
                    return View();
                }

                return PartialView("_GetUserEducations", educations);
            }
            else
                return View();
        }

        public IActionResult NewEducation(string userId)
        {
            var user = _context.Users.Where(x => x.UserGuid == userId).FirstOrDefault();
            ViewBag.UserId = user.UserId;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEducation(Education education)
        {
            var retUrl = Request.Headers["Referer"].ToString();

            if (education == null)
                return Redirect(retUrl);

            _context
                .Educations.Add(education);
            _context.SaveChanges();
            TempData["Message"] = "Kayıt başarılı!";


            return Redirect(retUrl);
        }

        public IActionResult EditEducation(int educationId)
        {
            var education = _context.Educations.Find(educationId);
            return View(education);

        }

        [HttpPost]
        public IActionResult Edit(Education education)
        {
            var retUrl = Request.Headers["Referer"].ToString();

            if (education == null)
                return Redirect(retUrl);

            _context
                .Educations.Update(education);
            _context.SaveChanges();
            TempData["Message"] = "Düzenleme işlemi başarılı!";


            return Redirect(retUrl);
        }

        public IActionResult DeleteEducation(int educationId)
        {
            var retUrl = Request.Headers["Referer"].ToString();

            var education = _context.Educations.Find(educationId);
            if(education == null)
                return Redirect(retUrl);

            _context
                .Educations.Remove(education);
            _context.SaveChanges();
            TempData["Message"] = "Silme işlemi başarılı!";


            return Redirect(retUrl);
        }
    }
}
