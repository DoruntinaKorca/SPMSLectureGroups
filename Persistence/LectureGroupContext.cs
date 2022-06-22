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

        public DbSet<LectureHall> LectureHalls { get; set; }

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


        }
    }
}