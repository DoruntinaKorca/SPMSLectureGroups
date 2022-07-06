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
    public class GetLectureGroupById
    {
        public class Query : IRequest<Result<LectureGroupDto>>
        {
            public int LectureGroupId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<LectureGroupDto>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<LectureGroupDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lectureGroup = await _context.LectureGroups
                    .Include(x => x.LGRS)
                    .FirstOrDefaultAsync(x => x.LectureGroupId == request.LectureGroupId);


                if (lectureGroup == null) return null;

                var result = _mapper.Map<LectureGroupDto>(lectureGroup);

                return Result<LectureGroupDto>.Success(result);
            }
        }
    }
}
