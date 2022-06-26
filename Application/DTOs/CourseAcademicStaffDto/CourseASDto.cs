using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CourseAcademicStaffDto
{
    public class CourseASDto
    {
        public CourseDto Course { get; set; }


        public AcademicStaffDto AcademicStaff { get; set; }
    }
}
