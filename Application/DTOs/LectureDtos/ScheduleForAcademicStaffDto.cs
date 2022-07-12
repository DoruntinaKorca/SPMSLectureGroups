using Application.DTOs.CourseAcademicStaffDto;
using Application.DTOs.LectureGroupDtos;
using Application.DTOs.LectureHallDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureDtos
{
    public class ScheduleForAcademicStaffDto
    {
        public int LectureId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public String LectureType { get; set; }

        public LectureHallDto LectureHall { get; set; }

        public DaysDto Day { get; set; }

        public CourseDto Course { get; set; }

        public LectureGroupForLectureDto LectureGroup { get; set; }
    }
}
