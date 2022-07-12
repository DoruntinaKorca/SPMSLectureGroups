using Application.DTOs.CourseAcademicStaffDto;
using Application.DTOs.LectureGroupDtos;
using Application.DTOs.LectureHallDtos;
using Application.DTOs.LGRSDtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureDtos
{
    public class LectureDto
    {
        public int LectureId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public String LectureType { get; set; }


        public DaysDto Day { get; set; }
        public LectureHallDto LectureHall { get; set; }

        public CourseDto Course { get; set; }

        public AcademicStaffDto AcademicStaff { get; set; }

        //  public CourseASDto CourseForAcademicStaff { get; set; }


        public LectureGroupForLectureDto LectureGroup { get; set; }
    }
}
