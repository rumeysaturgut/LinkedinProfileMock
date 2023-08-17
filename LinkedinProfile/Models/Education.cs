using System;
using System.Collections.Generic;

namespace LinkedinProfile.Models
{
    public partial class Education
    {
        public int EducationId { get; set; }
        public int UserId { get; set; }
        public string SchoolName { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public string FieldOfStudy { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Gpa { get; set; }
        public string? Description { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
