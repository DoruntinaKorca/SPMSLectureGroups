using Application.DTOs.CourseAcademicStaffDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureDtos
{
    public class RequestLectureDto
    {
        public int LectureId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public String LectureType { get; set; }

        public int LectureGroupId { get; set; }

        public int LectureHallId { get; set; }


    }
}
