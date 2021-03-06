using Application.DTOs.LectureGroupDtos;
using Application.DTOs.LectureHallDtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LGRSDtos
{
    public class LGRSDto
    {
        public int LGRSId { get; set; }
        public String Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public String LectureGroupSeasonStatus { get; set; }
        public int Faculty { get; set; }

        public int Semester { get; set; }
    }
}
