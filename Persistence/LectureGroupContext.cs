using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class LectureGroupContext : DbContext
    {
        public LectureGroupContext(DbContextOptions<LectureGroupContext> options) : base(options)
        {
        }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<LectureGroup> LectureGroups { get; set; }

        public DbSet<LectureGroupRegisteringSeason> LGRS { get; set; }

        public DbSet<Course_AcademicStaff> Course_AcademicStaff { get; set; }

        public DbSet<LectureHall> LectureHalls { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<AcademicStaff> AcademicStaff { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Lecture>()
                .HasOne(h=>h.LectureHall)
                .WithMany(le=>le.Lectures)
                .HasForeignKey(fk=>fk.LectureHallId)
                .HasConstraintName("Lectures_Halls")
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Lecture>()
                .HasOne(l => l.LectureGroup)
                .WithMany(le => le.Lectures)
                .HasForeignKey(fk => fk.LectureGroupId)
                .HasConstraintName("Lectures_Groups")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<LectureGroup>()
                .HasOne(lgrs => lgrs.LGRS)
                .WithMany(lg => lg.LectureGroups)
                .HasForeignKey(fk => fk.LGRSId)
                .HasConstraintName("LG_LGRS")
                .OnDelete(DeleteBehavior.Cascade);

           builder.Entity<Course_AcademicStaff>(x => x.HasKey(u => new { u.CourseId, u.AcademicStaffId }));
            //me shtu key mrena kejt me ni ven 

            builder.Entity<Course_AcademicStaff>()
               .HasOne(h => h.Course)
               .WithMany(le => le.CourseAcademicStaff)
               .HasForeignKey(fk => fk.CourseId)
               .HasConstraintName("courseAcademicStaff")
               .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Course_AcademicStaff>()
              .HasOne(h => h.AcademicStaff)
              .WithMany(le => le.CourseAcademicStaff)
              .HasForeignKey(fk => fk.AcademicStaffId)
              .HasConstraintName("academicStaffCourse")
              .OnDelete(DeleteBehavior.Cascade);

         

            builder.Entity<Lecture>(entity =>
            {

                entity.HasIndex(f => new { f.CourseId, f.AcademicStaffId });
                entity.HasKey(k => k.LectureId);
                entity.HasOne(l => l.Course_AcademicStaff)
                    .WithMany(le => le.Lectures)
                    .HasForeignKey(fk => new { fk.CourseId, fk.AcademicStaffId })
                    .HasConstraintName("courseAcademicSTAFF_FK")
                    .OnDelete(DeleteBehavior.Cascade);


            });



            builder.Entity<LectureHall>()
             .HasOne(l => l.Location)
            .WithMany(le => le.LectureHalls)
            .HasForeignKey(fk =>fk.LocationId)
            .HasConstraintName("locationhall")
            .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}