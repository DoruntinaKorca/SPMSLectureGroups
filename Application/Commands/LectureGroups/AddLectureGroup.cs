using Application.AsyncDataService;
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
            private readonly IMessageBusClient _messageBusClient;

            public Handler(LectureGroupContext context, IMapper mapper, IMessageBusClient messageBusClient)
            {
                _context = context;
                _mapper = mapper;
                _messageBusClient = messageBusClient;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var lectureGroup = _mapper.Map<LectureGroup>(request.LectureGroup);

                await _context.LectureGroups.AddAsync(lectureGroup);

                var result = await _context.SaveChangesAsync() > 0;


                try
                {
                    var lectureGroupPublishedDto = _mapper.Map<LectureGroupPublishedDto>(lectureGroup);

                    lectureGroupPublishedDto.Event = "LectureGroup_Published";

                    _messageBusClient.PublishNewLectureGroup(lectureGroupPublishedDto);

                  //  Console.WriteLine($"----> Could not send asynchronously");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"----> Could not send asynchronously:{ex.Message}");
                }



                if (!result) return Result<Unit>.Failure("Failed to add Lecture Group");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
