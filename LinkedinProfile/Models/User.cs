using System;
using System.Collections.Generic;

namespace LinkedinProfile.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            ConnectionConnectionUsers = new HashSet<Connection>();
            ConnectionUsers = new HashSet<Connection>();
            Educations = new HashSet<Education>();
            Experiences = new HashSet<Experience>();
            Likes = new HashSet<Like>();
            Posts = new HashSet<Post>();
            Profiles = new HashSet<Profile>();
            Shares = new HashSet<Share>();
            SkillUserUserRateds = new HashSet<SkillUser>();
            SkillUserUsers = new HashSet<SkillUser>();
        }

        public int UserId { get; set; }
        public string UserGuid { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Connection> ConnectionConnectionUsers { get; set; }
        public virtual ICollection<Connection> ConnectionUsers { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<Share> Shares { get; set; }
        public virtual ICollection<SkillUser> SkillUserUserRateds { get; set; }
        public virtual ICollection<SkillUser> SkillUserUsers { get; set; }
    }
}
