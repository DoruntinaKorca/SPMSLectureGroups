using Application.Core;
using Application.DTOs.LectureGroupDtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.LectureGroups
{
    public class GetLectureGroupsForSeason
    {
        public class Query : IRequest<Result<List<LectureGroupWithLecturesDto>>>
        {
            public int FacultyId { get; set; }
            //merri grupet me lectures mrena
            //dmth kthena grupe jo lectures
            //mi fshi ndb ato qe jone me data si tash mos mi lon 2 tnjejta
        }
        public class Handler : IRequestHandler<Query, Result<List<LectureGroupWithLecturesDto>>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<LectureGroupWithLecturesDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentlyOpenedLGRS = await GetCurrenlyOpenedLectureGroupRegisteringSeason(request.FacultyId);

                if (currentlyOpenedLGRS == null)
                    return Result<List<LectureGroupWithLecturesDto>>.Failure("No Lecture Group season is opened !!");


                var lectureGroups = await _context.LectureGroups.Where(x=>x.LGRSId == currentlyOpenedLGRS.LGRSId)
                  // .Include(x => x.LGRS)
                    .Include(x => x.Lectures)
                    .ThenInclude(c=>c.Course_AcademicStaff)
                    // .ThenInclude(c => c.Course_AcademicStaff)
                  // .ThenInclude(c => c.LectureHall)
                //   .Include(c => c.Lectur)
                /*  .Select(
                    x => new LectureGroup
                    {
                       LectureGroupId=x.LectureGroupId,
                       Lectures=x.Lectures,
                       GroupName=x.GroupName,
                       TimeSlot=x.TimeSlot
                    }) */
                .ToListAsync();

                var result = _mapper.Map<List<LectureGroupWithLecturesDto>>(lectureGroups);

                return Result<List<LectureGroupWithLecturesDto>>.Success(result);
            }
            private async Task<LectureGroupRegisteringSeason> GetCurrenlyOpenedLectureGroupRegisteringSeason(int facultyId)
            {
                return await _context.LGRS.Where(e =>
                        e.Faculty == facultyId
                        && (e.StartDate <= DateTime.Now
                            && e.EndDate > DateTime.Now))
                    .FirstOrDefaultAsync();
            }
        }
    }
}
