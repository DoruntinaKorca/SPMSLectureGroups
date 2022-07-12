using Application.Core;
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

namespace Application.Queries.Lectures
{
    public class GetScheduleForAcademicStaff
    {
        public class Query : IRequest<Result<List<ScheduleForAcademicStaffDto>>>
        {
            public Guid AcademicStaffId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<ScheduleForAcademicStaffDto>>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<ScheduleForAcademicStaffDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schedule = await _context.Lectures
                    .Include(x => x.LectureHall)
                    .ThenInclude(x => x.Location)
                    .Include(x => x.Day)
                    .Include(x => x.Course_AcademicStaff)
                    .Include(x => x.Course_AcademicStaff.Course)
                    .Include(x => x.LectureGroup)
                    .Where(x => x.Course_AcademicStaff.AcademicStaffId == request.AcademicStaffId)
                    .ToListAsync();


                if (schedule == null) return null;

                var result = _mapper.Map<List<ScheduleForAcademicStaffDto>>(schedule);

                return Result<List<ScheduleForAcademicStaffDto>>.Success(result);

            }
        }
    }
}
