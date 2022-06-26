using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum LectureType
    {
        Lecture,
        Exercise
    };
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public String LectureType { get; set; }
        public int LectureHallId { get; set; }

        public LectureHall LectureHall { get; set; }

        //course osht ne modul tjeter
        public int CourseId { get; set; }

        public Guid AcademicStaffId { get; set; }

        public Course_AcademicStaff Course_AcademicStaff { get; set; }

        public int LectureGroupId { get; set; }

        public LectureGroup LectureGroup { get; set; }
    }
}