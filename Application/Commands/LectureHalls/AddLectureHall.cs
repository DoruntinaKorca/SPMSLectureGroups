using Application.Core;
using Application.DTOs.LectureHallDtos;
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

namespace Application.Commands.LectureHalls
{
    public class AddLectureHall
    {
        public class Command : IRequest<Result<Unit>>
        {
            public RequestLectureHallDto LectureHallDto { get; set; }
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
                var lectureHall = _mapper.Map<LectureHall>(request.LectureHallDto);

                await _context.LectureHalls.AddAsync(lectureHall);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to add Lecture Hall");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
