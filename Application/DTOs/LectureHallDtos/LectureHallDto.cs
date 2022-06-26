using Application.DTOs.LocationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureHallDtos
{
    public class LectureHallDto
    {
        public int LectureHallId { get; set; }

        public String HallName { get; set; }

        public int Capacity { get; set; }


        public LocationDto Location { get; set; }
    }
}
