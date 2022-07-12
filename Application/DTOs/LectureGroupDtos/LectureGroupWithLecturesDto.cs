using Application.DTOs.LectureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureGroupDtos
{
    public class LectureGroupWithLecturesDto
    {
        public int LectureGroupId { get; set; }

        public String GroupName { get; set; }

        public TimeSlotDto TimeSlot { get; set; }
        public List<LectureWOGroupDto> Lectures { get; set; }
    
    }
}
