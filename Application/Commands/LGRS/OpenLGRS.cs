using Application.Core;
using Application.DTOs.LGRSDtos;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.LGRS
{
    public class OpenLGRS
    {
        public class Command : IRequest<Result<Unit>>
        {
            public LGRSDto LGRSDto { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly LectureGroupContext _context;
            private readonly IMapper _mapper;

            public Handler(LectureGroupContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

              
                var lgrs = _mapper.Map<LectureGroupRegisteringSeason>(request.LGRSDto);


                await _context.LGRS.AddAsync(lgrs);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to add Lecture");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
