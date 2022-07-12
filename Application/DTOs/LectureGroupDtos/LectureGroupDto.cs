using Application.DTOs.LGRSDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureGroupDtos
{
    public class LectureGroupDto
    {
        public int LectureGroupId { get; set; }

        public String GroupName { get; set; }

        public TimeSlotDto TimeSlot { get; set; }
      
        public LGRSDto LGRS { get; set; }
    }
}
