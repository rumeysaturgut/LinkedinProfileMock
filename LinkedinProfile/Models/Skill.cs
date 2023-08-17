using System;
using System.Collections.Generic;

namespace LinkedinProfile.Models
{
    public partial class Skill
    {
        public Skill()
        {
            SkillUsers = new HashSet<SkillUser>();
        }

        public int SkillId { get; set; }
        public string SkillName { get; set; } = null!;

        public virtual ICollection<SkillUser> SkillUsers { get; set; }
    }
}
