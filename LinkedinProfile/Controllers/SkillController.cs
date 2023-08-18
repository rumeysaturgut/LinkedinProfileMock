using LinkedinProfile.Helper;
using LinkedinProfile.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinkedinProfile.Controllers
{
    [Authorize]
    public class SkillController : BaseController
    {
        private readonly linkedinContext _context;

        public SkillController(linkedinContext context)
        {
            _context = context;
        }

        public IActionResult GetUserSkills(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var sql = @$"SELECT COUNT(DISTINCT su.user_rated_id) as SkillRatedCount ,s.skill_name as SkillName, s.skill_id AS Skilld 
                    FROM linkedin.dbo.skill_users su JOIN linkedin.dbo.skills s ON su.skill_id = s.skill_id
                    WHERE su.user_id={GetUserId()} GROUP BY s.skill_name, s.skill_id";

                var result = Extensions.RawSqlQuery(sql, x => new SkillVM
                {
                    SkillRatedCount = Convert.IsDBNull(x[0]) ? 0 : (int)x[0],
                    SkillName = Convert.IsDBNull(x[1]) ? 0 : x[1],
                    SkillId = Convert.IsDBNull(x[2]) ? 0 : x[2],
                    UserId = GetUserId(),
                });

                if (result == null)
                {
                    //TempData["Message"] = "Kullanıcıya ait deneyim bulunamadı";
                    return View();
                }

                return PartialView("_GetUserSkills", result);
            }
            else
                return View();
        }

        public IActionResult NewSkill(string userId)
        {
            var user = _context.Users.Where(x => x.UserGuid == userId).FirstOrDefault();
            ViewBag.UserId = user.UserId;
            ViewData["SkillsList"] = _context.Skills.ToList();
            return View();

        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            var retUrl = Request.Headers["Referer"].ToString();

            if (skill == null)
                return Redirect(retUrl);

            if(CheckIfUserHasSkill(skill.SkillId))
            {
                TempData["ErrorMessage"] = "Bu yetenek zaten ekli";
                return Redirect(retUrl);
            }

            SkillUser skillUser = new SkillUser
                {
                SkillId = skill.SkillId,
                UserId = GetUserId()
                };

            _context
                .SkillUsers.Add(skillUser);
            _context.SaveChanges();
            TempData["Message"] = "Kayıt başarılı!";


            return Redirect(retUrl);
        }

        public bool CheckIfUserHasSkill(int skillId)
        {
            var userId = GetUserId();

            return _context.SkillUsers.Where(x => x.SkillId == skillId && x.UserId == userId).Any();

        }

        public IActionResult DeleteSkill(int skillId, int userId)
        {
            var retUrl = Request.Headers["Referer"].ToString();

            var skillUser = _context.SkillUsers.Where(x => x.UserId == userId && x.SkillId == skillId).FirstOrDefault();
            if (skillUser == null)
                return Redirect(retUrl);

            _context
                .SkillUsers.Remove(skillUser);
            _context.SaveChanges();
            TempData["Message"] = "Silme işlemi başarılı!";


            return Redirect(retUrl);
        }
    }
}
