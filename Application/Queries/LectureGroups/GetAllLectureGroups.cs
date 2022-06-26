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
        public class Query : IRequest<List<LectureGroupDto>>
        {

        }
        public class Handler : IRequestHandler<Query, List<LectureGroupDto>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LectureGroupDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lectures = await _context.LectureGroups
                    .Include(x=>x.LGRS)
                    .ToListAsync();

                var result = _mapper.Map<List<LectureGroupDto>>(lectures);

                return result;
            }
        }
    }
}
