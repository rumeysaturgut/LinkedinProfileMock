using System;
using System.Collections.Generic;

namespace LinkedinProfile.Models
{
    public partial class Profile
    {
        public int ProfileId { get; set; }
        public string Headline { get; set; } = null!;
        public string? Summary { get; set; }
        public string Industry { get; set; } = null!;
        public string? Website { get; set; }
        public int Connections { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
