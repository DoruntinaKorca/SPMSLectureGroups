using Application.Core;
using Application.DTOs.LectureHallDtos;
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

namespace Application.Queries.LectureHalls
{
    public class GetAllLectureHalls
    {
        public class Query : IRequest<Result<List<LectureHallDto>>>
        {

        }
        public class Handler : IRequestHandler<Query, Result<List<LectureHallDto>>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<LectureHallDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lectures = await _context.LectureHalls
                    .Include(x=>x.Location)
                    .ToListAsync();
             
                var result = _mapper.Map<List<LectureHallDto>>(lectures);

                return Result<List<LectureHallDto>>.Success(result);
            }
        }
    }
}
