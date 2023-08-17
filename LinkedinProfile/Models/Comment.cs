using System;
using System.Collections.Generic;

namespace LinkedinProfile.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Context { get; set; } = null!;
        public DateTime CommentDate { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
