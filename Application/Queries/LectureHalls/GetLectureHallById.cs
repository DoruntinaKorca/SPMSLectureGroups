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
    public class GetLectureHallById
    {
        public class Query : IRequest<LectureHallDto>
        {
            public int LectureHallId { get; set; }
        }
        public class Handler : IRequestHandler<Query, LectureHallDto>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LectureHallDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var lectureHall = await _context.LectureHalls
                    .Include(x => x.Location)
                    .FirstOrDefaultAsync(x => x.LectureHallId == request.LectureHallId);


                if (lectureHall == null) return null;

                var result = _mapper.Map<LectureHallDto>(lectureHall);

                return result;
            }
        }
    }
}
