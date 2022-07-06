using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureHallDtos
{
    public class RequestLectureHallDto
    {
        public String HallName { get; set; }

        public int Capacity { get; set; }

        public int LocationId { get; set; }
    }
}
