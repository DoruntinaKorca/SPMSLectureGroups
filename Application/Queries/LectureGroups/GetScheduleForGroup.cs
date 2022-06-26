using Application.DTOs.LectureDtos;
using AutoMapper;
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
    public class GetScheduleForGroup
    {
        public class Query : IRequest<List<ScheduleForStudentDto>>
        {
            public int LectureGroupId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<ScheduleForStudentDto>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ScheduleForStudentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schedule = await _context.Lectures
                    .Include(x => x.LectureHall)
                    .ThenInclude(x => x.Location)
                    .Include(x => x.Course_AcademicStaff)
                    .Include(x => x.Course_AcademicStaff.Course)
                    .Include(x => x.Course_AcademicStaff.AcademicStaff)
                    .Include(x => x.LectureGroup)
                    .Where(x => x.LectureGroupId == request.LectureGroupId)
                    .ToListAsync();


                if (schedule == null) return null;

                var result = _mapper.Map<List<ScheduleForStudentDto>>(schedule);

                return result;
            }
        }
    }
}
