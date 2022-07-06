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

namespace Application.Commands.LectureGroups
{
    public class DeleteLectureGroup
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int LectureGroupId { get; set; }
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
                var lectureGroup = await _context.LectureGroups.FindAsync(request.LectureGroupId);

                _context.Remove(lectureGroup);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete Lecture Group");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
