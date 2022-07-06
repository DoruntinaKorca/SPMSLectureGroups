using Application.Core;
using Application.DTOs.LectureGroupDtos;
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

namespace Application.Commands.LectureGroups
{
    public class AddLectureGroup
    {
        public class Command : IRequest<Result<Unit>>
        {
            public RequestLectureGroupDto LectureGroup { get; set; }
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
                var lectureGroup = _mapper.Map<LectureGroup>(request.LectureGroup);

                await _context.LectureGroups.AddAsync(lectureGroup);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to add Lecture Group");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
