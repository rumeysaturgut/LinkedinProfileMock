using LinkedinProfile.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinProfile.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        private readonly linkedinContext _context;

        public ExperienceController(linkedinContext context)
        {
            _context = context;
        }

        public IActionResult GetUserExperiences(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var experiences = _context.Experiences.Where(e => e.User.UserGuid == id).OrderByDescending(o => o.ExperienceId).ToList();
                if (experiences == null)
                {
                    //TempData["Message"] = "Kullanıcıya ait deneyim bulunamadı";
                    return View();
                }


                var experiencesVM = experiences.Select(x => new ExperienceVM
                {
                    Id = x.ExperienceId,
                    CompanyName = x.CompanyName,
                    Title = x.Title,
                    StartDate = SetDateFormat(x.StartDate),
                    EndDate = x.EndDate == null ? "Halen" : SetDateFormat(x.EndDate)
                });



                return PartialView("_GetUserExperiences", experiencesVM);
            }
            else
                return View();
        }

        public string SetDateFormat(DateTime? date)
        {
            string monthName = date?.ToString("MMM");
            return $"{monthName} {date?.Year}";
        }

        public IActionResult NewExperience(string userId)
        {
            var user = _context.Users.Where(x => x.UserGuid == userId).FirstOrDefault();
            ViewBag.UserId = user.UserId;
            return View();

        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            var retUrl = Request.Headers["Referer"].ToString();

            if (experience == null)
                return Redirect(retUrl);

            _context
                .Experiences.Add(experience);
            _context.SaveChanges();
            TempData["Message"] = "Kayıt başarılı!";


            return Redirect(retUrl);
        }

        public IActionResult EditExperience(int experienceId)
        {
            var experience = _context.Experiences.Find(experienceId);
            return View(experience);

        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            var retUrl = Request.Headers["Referer"].ToString();

            if (experience == null)
                return Redirect(retUrl);

            _context
                .Experiences.Update(experience);
            _context.SaveChanges();
            TempData["Message"] = "Düzenleme işlemi başarılı!";


            return Redirect(retUrl);
        }

        public IActionResult DeleteExperience(int experienceId)
        {
            var retUrl = Request.Headers["Referer"].ToString();

            var experience = _context.Experiences.Find(experienceId);
            if (experience == null)
                return Redirect(retUrl);

            _context
                .Experiences.Remove(experience);
            _context.SaveChanges();
            TempData["Message"] = "Silme işlemi başarılı!";


            return Redirect(retUrl);
        }
    }
}
