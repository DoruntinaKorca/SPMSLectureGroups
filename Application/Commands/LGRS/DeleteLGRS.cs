using Application.Core;
using AutoMapper;
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
    public class DeleteLGRS
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int LGRSId { get; set; }
        }
        public class Handler : IRequestHandler<Command,Result<Unit>>
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
                var lgrs = await _context.LGRS.FindAsync(request.LGRSId);

                _context.Remove(lgrs);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete Lecture Group Registering Season!");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
