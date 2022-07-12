using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LectureGroup
    {
        [Key]
        public int LectureGroupId { get; set; }

        public String GroupName { get; set; }

       // public String TimeSlot { get; set; }
        public int LGRSId { get; set; }

        public int? TimeSlotId { get; set; }

        public TimeSlot TimeSlot { get; set; }
        public LectureGroupRegisteringSeason LGRS { get; set; }

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
    }
}
