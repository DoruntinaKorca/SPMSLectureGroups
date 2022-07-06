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

namespace Application.Commands.LectureHalls
{
    public class DeleteLectureHall
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int LectureHallId { get; set; }
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
                var lectureHall =await _context.LectureHalls.FindAsync(request.LectureHallId);

                _context.Remove(lectureHall);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete Lecture Hall");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
