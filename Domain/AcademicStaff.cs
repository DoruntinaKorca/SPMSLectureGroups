using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AcademicStaff
    {
        [Key]
        public Guid AcademicStaffId { get; set; }

        public String FullName { get; set; }

        public ICollection<Course_AcademicStaff> CourseAcademicStaff { get; set; } = new List<Course_AcademicStaff>();
    }
}
