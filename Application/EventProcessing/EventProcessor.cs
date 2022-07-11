using Application.Data;
using Application.DTOs.LectureDtos;
using AutoMapper;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.AcademicStaffPublished:
                    addAcademicStaff(message);
                    break;
                case EventType.UserDeleted:
                    deleteAcademicStaff(message);
                    break;
                default:
                    break;
            }
        }
        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("---> determining event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType.Event)
            {
                case "AcademicStaff_Published":
                    Console.WriteLine("---> AcademicStaff Published Event Detected");
                    return EventType.AcademicStaffPublished;
                case "Deleted_User_Published":
                    Console.WriteLine("---> DeleteUserf Published Event Detected");
                    return EventType.UserDeleted;
                default:
                    Console.WriteLine("---> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void addAcademicStaff(string academicStaffPublishedMessage)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ILectureGroupRepo>();
            
            var academicStaffPublishedDto = JsonSerializer
                .Deserialize<AcademicStaffPublishedDto>(academicStaffPublishedMessage);

            try
            {
                var academicStaff = _mapper.Map<AcademicStaff>(academicStaffPublishedDto);
                    if (!repo.ExternalAcademicStaffExists(academicStaff.AcademicStaffId))
                    {
                        repo.CreateAcademicStaff(academicStaff);
                        repo.SaveChanges();
                        Console.WriteLine("--->AcademicStaff added...");

                   }
                    else
                    {
                        Console.WriteLine("--->AcademicStaff already exists...");
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"---> could not add AademicStaff to DB {ex.Message}");
            }
            }
        }
        private void deleteAcademicStaff(string academicStaffPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ILectureGroupRepo>();

                var academicStaffDeletedDto = JsonSerializer
                    .Deserialize<DeleteAcademicStaffPublishedDto>(academicStaffPublishedMessage);

                try
                {
                    var academicStaff = _mapper.Map<AcademicStaff>(academicStaffDeletedDto);
                    
                        repo.DeleteAcademicStaff(academicStaff);
                        repo.SaveChanges();
                        Console.WriteLine("--->AcademicStaff deleted...");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"---> could not delete AcademicStaff from DB {ex.Message}");
                }
            }
        }

    }
    enum EventType
    {
        AcademicStaffPublished,
        UserDeleted,
        Undetermined
    }
}
