using Microsoft.EntityFrameworkCore;
using Monolith.Domain.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.Domain.Context
{
    public class PrimarydbContext : DbContext
    {

        public PrimarydbContext(DbContextOptions<PrimarydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Lecture> Lecture { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("appuser_pkey");

                entity.ToTable("appuser");

                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstname")
                    .HasMaxLength(255);

                entity.Property(e => e.InstructorRating).HasColumnName("instructorrating");

                entity.Property(e => e.IsApproved).HasColumnName("isapproved");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastname")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId).HasColumnName("courseid");

                entity.Property(e => e.CourseDescription).HasColumnName("coursedescription");

                entity.Property(e => e.CourseName)
                    .HasColumnName("coursename")
                    .HasMaxLength(255);

                entity.Property(e => e.InstructorId).HasColumnName("instructorid");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("course_instructorid_fkey");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("lecture");

                entity.Property(e => e.LectureId).HasColumnName("lectureid");

                entity.Property(e => e.LectureName)
                    .HasColumnName("lecturename")
                    .HasMaxLength(255);

                entity.Property(e => e.TopicId).HasColumnName("topicid");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Lecture)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lecture_topicid_fkey");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.Property(e => e.TopicId).HasColumnName("topicid");

                entity.Property(e => e.CourseId).HasColumnName("courseid");

                entity.Property(e => e.CreatedOn).HasColumnName("createdon");

                entity.Property(e => e.TopicOrder).HasColumnName("topicorder");

                entity.Property(e => e.TopicDescription)
                    .HasColumnName("topicdescription")
                    .HasMaxLength(500);

                entity.Property(e => e.TopicName)
                    .HasColumnName("topicname")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("topic_courseid_fkey");
            });


            modelBuilder.Entity<AppUserCourse>()
                .HasKey(auc => new { auc.UserId, auc.CourseId });
            modelBuilder.Entity<AppUserCourse>()
                .HasOne(auc => auc.AppUser)
                .WithMany(au => au.Courses)
                .HasForeignKey(au => au.UserId);
            modelBuilder.Entity<AppUserCourse>()
                .HasOne(auc => auc.Course)
                .WithMany(c => c.AppUsers)
                .HasForeignKey(auc => auc.CourseId);

        }
    }
}
