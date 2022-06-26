using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public String CourseName { get; set; }

        public ICollection<Course_AcademicStaff> CourseAcademicStaff { get; set; } = new List<Course_AcademicStaff>();
    }
}
