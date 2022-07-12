using Application.Core;
using Application.DTOs.LectureGroupDtos;
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
    public class GetAllLectureGroups
    {
        public class Query : IRequest<Result<List<LectureGroupDto>>>
        {

        }
        public class Handler : IRequestHandler<Query, Result<List<LectureGroupDto>>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<LectureGroupDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lecturegroups = await _context.LectureGroups
                    .Include(x=>x.LGRS)
                    .Include(x => x.TimeSlot)
                    .ToListAsync();

                var result = _mapper.Map<List<LectureGroupDto>>(lecturegroups);

                return Result<List<LectureGroupDto>>.Success(result);
            }
        }
    }
}
