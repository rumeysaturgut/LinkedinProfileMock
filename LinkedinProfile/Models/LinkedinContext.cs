using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LinkedinProfile.Models
{
    public partial class linkedinContext : DbContext
    {
        public linkedinContext()
        {
        }

        public linkedinContext(DbContextOptions<linkedinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Connection> Connections { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Experience> Experiences { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Share> Shares { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<SkillUser> SkillUsers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=PCUSK0022;initial catalog=linkedin;user id=sa;password=root1234;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CommentDate)
                    .HasColumnType("date")
                    .HasColumnName("comment_date");

                entity.Property(e => e.Context)
                    .HasColumnType("text")
                    .HasColumnName("context");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comments_posts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comments_users");
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.ToTable("connections");

                entity.Property(e => e.ConnectionId).HasColumnName("connection_id");

                entity.Property(e => e.ConnectionStatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("connection_status");

                entity.Property(e => e.ConnectionUserId).HasColumnName("connection_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ConnectionUser)
                    .WithMany(p => p.ConnectionConnectionUsers)
                    .HasForeignKey(d => d.ConnectionUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_connections_users1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConnectionUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_connections_users");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("educations");

                entity.Property(e => e.EducationId).HasColumnName("education_id");

                entity.Property(e => e.Degree)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("degree");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.FieldOfStudy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("field_of_study");

                entity.Property(e => e.Gpa).HasColumnName("gpa");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("school_name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_educations_users");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("experiences");

                entity.Property(e => e.ExperienceId).HasColumnName("experience_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_experiences_users");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.ToTable("likes");

                entity.Property(e => e.LikeId).HasColumnName("like_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_likes_posts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_likes_users");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.Context)
                    .HasColumnType("text")
                    .HasColumnName("context");

                entity.Property(e => e.PostDate)
                    .HasColumnType("date")
                    .HasColumnName("post_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_posts_users");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profiles");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Connections).HasColumnName("connections");

                entity.Property(e => e.Headline)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("headline");

                entity.Property(e => e.Industry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("industry");

                entity.Property(e => e.Summary)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("summary");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Website)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("website");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_profiles_users1");
            });

            modelBuilder.Entity<Share>(entity =>
            {
                entity.ToTable("shares");

                entity.Property(e => e.ShareId).HasColumnName("share_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Shares)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shares_posts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Shares)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shares_users");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skills");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("skill_name");
            });

            modelBuilder.Entity<SkillUser>(entity =>
            {
                entity.ToTable("skill_users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserRatedId).HasColumnName("user_rated_id");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.SkillUsers)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_skill_users_skills");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SkillUserUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_skill_users_users");

                entity.HasOne(d => d.UserRated)
                    .WithMany(p => p.SkillUserUserRateds)
                    .HasForeignKey(d => d.UserRatedId)
                    .HasConstraintName("FK_skill_users_users1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.JoinDate)
                    .HasColumnType("datetime")
                    .HasColumnName("join_date");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.Property(e => e.UserGuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("user_guid")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
