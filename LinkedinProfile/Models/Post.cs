using System;
using System.Collections.Generic;

namespace LinkedinProfile.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            Shares = new HashSet<Share>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Context { get; set; } = null!;
        public DateTime PostDate { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Share> Shares { get; set; }
    }
}
