using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Day
    {
        [Key]
        public int DayId { get; set; }

        public String DayName { get; set; }

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
    }
}
