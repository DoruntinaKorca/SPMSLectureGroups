using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LectureHall
    {
        [Key]
        public int LectureHallId { get; set; }

        public String HallName { get; set; }

        public int Capacity { get; set; }

        public int Location { get; set; }

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
    }
}