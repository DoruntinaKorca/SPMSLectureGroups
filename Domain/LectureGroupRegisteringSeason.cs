using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum LectureGroupSeasonStatus
    {
        //me ja ndrru emrin me bo lectureGroupSeasonStatus
        Opened,
        Closed,
        In_Process
    }
    public class LectureGroupRegisteringSeason
    {
        [Key]
        public int LGRSId { get; set; }

        public String Description { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public String LectureGroupSeasonStatus { get; set; }
        public int Faculty { get; set; }

        public int Semester { get; set; }

        public ICollection<LectureGroup> LectureGroups { get; set; } = new List<LectureGroup>();
    }
}
