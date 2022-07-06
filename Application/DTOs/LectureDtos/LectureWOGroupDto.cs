using Application.DTOs.CourseAcademicStaffDto;
using Application.DTOs.LectureHallDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureDtos
{
    public class LectureWOGroupDto
    {
       

      //  public CourseDto Course { get; set; }

     //   public AcademicStaffDto AcademicStaff { get; set; }


        public int LectureId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public String LectureType { get; set; }
        public int LectureHallId { get; set; }


    }
}
