using Application.Core;
using Application.DTOs.CourseAcademicStaffDto;
using Application.DTOs.LectureDtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Lectures
{
    public class AddLecture
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int CourseId { get; set; }
            public Guid AcademicStaffId { get; set; }
            //hall edhe group jone ne dto
            public RequestLectureDto LectureDto { get; set; }
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

                var courseAcademicStaff = await _context.Course_AcademicStaff
                    .Where(x=>x.CourseId == request.CourseId && x.AcademicStaffId == request.AcademicStaffId)
                    .FirstOrDefaultAsync();


                var lecture = _mapper.Map<Lecture>(request.LectureDto);

                lecture.Course_AcademicStaff = courseAcademicStaff;

                await _context.Lectures.AddAsync(lecture);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to add Lecture");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
