using Application.Core;
using Application.DTOs.LectureDtos;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Lectures
{
    public class EditLecture
    {
        public class Command : IRequest<Result<Unit>>
        {
            public RequestLectureDto LectureDto { get; set; }

            public int LectureId { get; set; }
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
                var lecture = await _context.Lectures.FindAsync(request.LectureId);

                _mapper.Map(request.LectureDto, lecture);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit Lecture");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
