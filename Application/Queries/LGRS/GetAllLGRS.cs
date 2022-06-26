using Application.DTOs.LGRSDtos;
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

namespace Application.Queries.LGRS
{
    public class GetAllLGRS
    {
        public class Query : IRequest<List<LGRSDto>>
        {

        }
        public class Handler : IRequestHandler<Query, List<LGRSDto>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LGRSDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lectures = await _context.LGRS.ToListAsync();

                var result = _mapper.Map<List<LGRSDto>>(lectures);

                return result;
            }
        }
    }
}
