using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TimeSlot
    {
        [Key]
        public int TimeSlotId { get; set; }

        public String SlotName { get; set; }

        public ICollection<LectureGroup> LectureGroups { get; set; } = new List<LectureGroup>();
    }
}
