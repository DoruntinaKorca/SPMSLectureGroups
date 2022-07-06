using Application.Core;
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
    public class GetLGRSById
    {
        public class Query : IRequest<Result<LGRSDto>>
        {
            public int LGRSId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<LGRSDto>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<LGRSDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lgrs = await _context.LGRS
                    .FirstOrDefaultAsync(x => x.LGRSId == request.LGRSId);


                if (lgrs == null) return null;

                var result = _mapper.Map<LGRSDto>(lgrs);

                return Result<LGRSDto>.Success(result);
            }
        }
    }
}
