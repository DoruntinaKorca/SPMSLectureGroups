using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course_AcademicStaff
    {
        public int CourseId { get; set; }


        public Course Course { get; set; }

        public Guid AcademicStaffId { get; set; }

      
        public AcademicStaff AcademicStaff { get; set; }

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
    }
}
