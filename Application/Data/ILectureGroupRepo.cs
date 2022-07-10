using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface ILectureGroupRepo
    {
        bool ExternalAcademicStaffExists(Guid externalAcademicStaffId);

        void CreateAcademicStaff(AcademicStaff aStaff);

        bool SaveChanges();
    }
}
