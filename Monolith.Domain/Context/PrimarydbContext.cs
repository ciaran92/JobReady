using System;
using Microsoft.EntityFrameworkCore;
using Monolith.Domain.BusinessObjects;

namespace Monolith.Domain.Context
{
    public class PrimarydbContext : DbContext
    {
        
        public PrimarydbContext(DbContextOptions<PrimarydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appuser> Appuser { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Lecture> Lecture { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("host=localhost;database=Primarydb;user id=postgres;password=cman4135;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Appuser>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("appuser_pkey");

                entity.ToTable("appuser");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(255);

                entity.Property(e => e.Instructorrating).HasColumnName("instructorrating");
                
                entity.Property(e => e.Isapproved).HasColumnName("isapproved");

                entity.Property(e => e.Lastname)
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

                entity.Property(e => e.Lectureid).HasColumnName("lectureid");

                entity.Property(e => e.Lecturename)
                    .HasColumnName("lecturename")
                    .HasMaxLength(255);

                entity.Property(e => e.Topicid).HasColumnName("topicid");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Lecture)
                    .HasForeignKey(d => d.Topicid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lecture_topicid_fkey");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.Property(e => e.Topicid).HasColumnName("topicid");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Topicname)
                    .HasColumnName("topicname")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("topic_courseid_fkey");
            });
        }
    }
}
