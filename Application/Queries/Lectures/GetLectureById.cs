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
    public class GetLectureById
    {
        public class Query : IRequest<Result<LectureDto>>
        {
            public int LectureId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<LectureDto>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<LectureDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lectures = await _context.Lectures
                   .Include(x => x.LectureHall)
                    .ThenInclude(x => x.Location)
                    .Include(x => x.Course_AcademicStaff)
                    .Include(x => x.Course_AcademicStaff.Course)
                    .Include(x => x.Course_AcademicStaff.AcademicStaff)
                    .Include(x => x.LectureGroup)
                    .FirstOrDefaultAsync(x => x.LectureId == request.LectureId);


                if (lectures == null) return null;

                var result = _mapper.Map<LectureDto>(lectures);

                return Result<LectureDto>.Success(result);
            }
        }
    }
}
