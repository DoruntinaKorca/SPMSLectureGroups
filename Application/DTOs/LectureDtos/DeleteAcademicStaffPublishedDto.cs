using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LectureDtos
{
    public class DeleteAcademicStaffPublishedDto
    {
        public Guid AcademicStaffId { get; set; }

        public String Event { get; set; }
    }
}
