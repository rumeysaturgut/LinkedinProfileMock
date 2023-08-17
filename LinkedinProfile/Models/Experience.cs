using System;
using System.Collections.Generic;

namespace LinkedinProfile.Models
{
    public partial class Experience
    {
        public int ExperienceId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
