using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public class LectureGroupRepo : ILectureGroupRepo
    {
        private readonly LectureGroupContext _context;

        public LectureGroupRepo(LectureGroupContext context)
        {
            _context = context;
        }

        public void CreateAcademicStaff(AcademicStaff aStaff)
        {
          if(aStaff == null) throw new ArgumentNullException(nameof(aStaff));

          _context.AcademicStaff.Add(aStaff);
        }

        public void DeleteAcademicStaff(AcademicStaff aStaff)
        {
            var us = _context.AcademicStaff.FirstOrDefault(x => x.AcademicStaffId == aStaff.AcademicStaffId);
            _context.AcademicStaff.Remove(us);
        }

        public bool ExternalAcademicStaffExists(Guid academicStaffId)
        {
            return _context.AcademicStaff.Any(a => a.AcademicStaffId == academicStaffId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
