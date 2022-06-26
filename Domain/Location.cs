using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public String Name { get; set; }

        public ICollection<LectureHall> LectureHalls { get; set; } = new List<LectureHall>();
    }
}
